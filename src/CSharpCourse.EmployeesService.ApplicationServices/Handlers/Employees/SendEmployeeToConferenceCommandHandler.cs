using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Confluent.Kafka;
using CSharpCourse.Core.Lib.Enums;
using CSharpCourse.Core.Lib.Events;
using CSharpCourse.EmployeesService.ApplicationServices.MessageBroker;
using CSharpCourse.EmployeesService.ApplicationServices.Models;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.Domain.Contracts.Repositories;
using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers.Employees
{
    public class SendEmployeeToConferenceCommandHandler : IRequestHandler<SendEmployeeToConferenceCommand>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IProducerBuilderWrapper _producerBuilderWrapper;

        public SendEmployeeToConferenceCommandHandler(IConferenceRepository conferenceRepository,
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            IProducerBuilderWrapper producerBuilderWrapper)
        {
            _conferenceRepository = conferenceRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _producerBuilderWrapper = producerBuilderWrapper;
        }

        public async Task<Unit> Handle(SendEmployeeToConferenceCommand request, CancellationToken cancellationToken)
        {
            // Проверить что сотрудник существует
            var emp = await _employeeRepository.GetByIdWithIncludesAsync(request.EmployeeId, cancellationToken);
            if (emp is null)
                throw new Exception($"Employee with id {request.EmployeeId} not found in store");

            // Проверить что конференция еще не прошла
            var conf = await _conferenceRepository.CheckIsConferenceIsNotEndAsync(request.ConferenceId,
                cancellationToken);
            if (conf is null)
                throw new Exception($"Conference with id {request.ConferenceId} not found or is end");

            // Проверить что данный сотрудник еще не был на этой конференции
            if (emp.Conferences.Select(it => it.Id).Contains(request.EmployeeId))
                throw new Exception($"Employee with id {request.EmployeeId} was registered in " +
                                    $"conference with id {request.ConferenceId}");

            // Записать что сотрудник идет на коференцию
            emp.Conferences.Add(conf);
            await _employeeRepository.UpdateAsync(emp, cancellationToken);

            // Отправить запрос на выдачу мерча
            await _producerBuilderWrapper.Producer.ProduceAsync(_producerBuilderWrapper.MoveToConferenceTopic,
                new Message<string, string>()
                {
                    Key = emp.Id.ToString(),
                    Value = JsonSerializer.Serialize(new NotificationEvent()
                    {
                        EmployeeEmail = emp.Email,
                        EmployeeName = $"{emp.LastName} {emp.FirstName} {emp.MiddleName}",
                        EventType = EmployeeEventType.ConferenceAttendance,
                        Payload = new MerchDeliveryEventPayload()
                        {
                            MerchType = request.AsWhom switch
                            {
                                EmployeeInConferenceType.AsListener => MerchType.ConferenceListenerPack,
                                EmployeeInConferenceType.AsSpeaker => MerchType.ConferenceSpeakerPack,
                                _ => throw new Exception("Merch type not defined")
                            }
                        }
                    })
                }, cancellationToken);

            return Unit.Value;
        }
    }
}

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeesService.ApplicationServices.Models.Commands;
using EmployeesService.Core.Contracts.Repositories;
using MediatR;

namespace EmployeesService.ApplicationServices.Handlers.Employees
{
    public class SendEmployeeToConferenceCommandHandler : IRequestHandler<SendEmployeeToConferenceCommand>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public SendEmployeeToConferenceCommandHandler(IConferenceRepository conferenceRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _conferenceRepository = conferenceRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
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

            return Unit.Value;
        }
    }
}

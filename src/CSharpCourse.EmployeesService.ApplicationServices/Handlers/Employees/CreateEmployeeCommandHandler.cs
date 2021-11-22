using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using AutoMapper;
using Confluent.Kafka;
using CSharpCourse.Core.Lib.Enums;
using CSharpCourse.Core.Lib.Events;
using CSharpCourse.EmployeesService.ApplicationServices.MessageBroker;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Employee;
using CSharpCourse.EmployeesService.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Employee = CSharpCourse.EmployeesService.Domain.Models.Entities.Employee;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers.Employees
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, long>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProducerBuilderWrapper _producerBuilderWrapper;
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;

        public CreateEmployeeCommandHandler(IEmployeeRepository repository,
            IMapper mapper,
            IProducerBuilderWrapper producerBuilderWrapper,
            IUnitOfWork unitOfWork,
            ILogger<CreateEmployeeCommandHandler> logger = null)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _producerBuilderWrapper = producerBuilderWrapper;
            _unitOfWork = unitOfWork;
            _logger = logger ?? NullLogger<CreateEmployeeCommandHandler>.Instance;
        }

        public async Task<long> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Подготовка модели для создания нового сотрудника
            var dto = _mapper.Map<Employee>(request);
            dto.HiringDate = DateTime.UtcNow;
            dto.FiredDate = null;

            var employee = await _employeeRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (employee is not null)
                throw new Exception($"Email {request.Email} already taken");

            await _unitOfWork.StartTransaction(cancellationToken);

            // Создаем сотрудника
            var employeeId = await _employeeRepository.CreateAsync(dto, cancellationToken);

            // Отправляем заявку, что сотрудник создан, и нужно выдать мерч
            await _producerBuilderWrapper.Producer.ProduceAsync(_producerBuilderWrapper.CreateNewEmployeeTopic,
                new Message<string, string>()
                {
                    Key = employeeId.ToString(),
                    Value = JsonSerializer.Serialize(new NotificationEvent()
                    {
                        EmployeeEmail = dto.Email,
                        EmployeeName = $"{dto.LastName} {dto.FirstName} {dto.MiddleName}",
                        EventType = EmployeeEventType.Hiring,
                        Payload = new MerchDeliveryEventPayload()
                        {
                            MerchType = MerchType.WelcomePack,
                            ClothingSize = (ClothingSize)dto.ClothingSize
                        }
                    })
                }, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return dto.Id;
        }
    }
}

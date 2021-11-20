using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Confluent.Kafka;
using CSharpCourse.Core.Lib.Enums;
using CSharpCourse.Core.Lib.Events;
using CSharpCourse.EmployeesService.ApplicationServices.MessageBroker;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.Domain.Contracts.Repositories;
using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers.Employees
{
    public class DismissEmployeeCommandHandler : IRequestHandler<DismissEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProducerBuilderWrapper _producerBuilderWrapper;
        private readonly IMapper _mapper;

        public DismissEmployeeCommandHandler(IEmployeeRepository repository,
            IMapper mapper,
            IProducerBuilderWrapper producerBuilderWrapper)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _producerBuilderWrapper = producerBuilderWrapper;
        }

        public async Task<Unit> Handle(DismissEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Увольняем сотрудника
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (employee is null)
                throw new Exception($"Employee with id {request.Id} not found or is already fired");

            await _employeeRepository.DismissAsync(employee, cancellationToken);

            // Отправляем эвент о том что сотрудник уволен
            _producerBuilderWrapper.Producer.Produce(_producerBuilderWrapper.DismissEmployeeTopic,
                new Message<string, string>()
                {
                    Key = request.Id.ToString(),
                    Value = JsonSerializer.Serialize(new NotificationEvent()
                    {
                        EmployeeEmail = employee.Email,
                        EmployeeName = $"{employee.LastName} {employee.FirstName} {employee.MiddleName}",
                        EventType = EmployeeEventType.Dismissal
                    })
                });

            return Unit.Value;
        }
    }
}

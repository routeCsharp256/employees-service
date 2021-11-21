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
using CSharpCourse.EmployeesService.Domain.AggregationModels.Employee;
using CSharpCourse.EmployeesService.Domain.Contracts;
using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers.Employees
{
    public class DismissEmployeeCommandHandler : IRequestHandler<DismissEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProducerBuilderWrapper _producerBuilderWrapper;
        private readonly IMapper _mapper;

        public DismissEmployeeCommandHandler(IEmployeeRepository repository,
            IMapper mapper,
            IProducerBuilderWrapper producerBuilderWrapper,
            IUnitOfWork unitOfWork)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _producerBuilderWrapper = producerBuilderWrapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DismissEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Увольняем сотрудника
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (employee is null)
                throw new Exception($"Employee with id {request.Id} not found");

            if(employee.IsFired)
                throw new Exception($"Employee with id {request.Id} already fired");

            await _unitOfWork.StartTransaction(cancellationToken);

            employee.FiredDate = DateTime.Now;
            employee.IsFired = true;

            await _employeeRepository.UpdateAsync(employee, cancellationToken);

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

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

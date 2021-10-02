using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using AutoMapper;
using EmployeesService.Core.Models.Entities;
using EmployeesService.ApplicationServices.Models.Commands;
using EmployeesService.Core.Contracts.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeesService.ApplicationServices.Handlers.Employees
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, long>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;

        public CreateEmployeeCommandHandler(IEmployeeRepository repository,
            IMapper mapper,
            ILogger<CreateEmployeeCommandHandler> logger = null)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _logger = logger ?? NullLogger<CreateEmployeeCommandHandler>.Instance;
        }

        public Task<long> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Подготовка модели для создания нового сотрудника
            var dto = _mapper.Map<Employee>(request);
            dto.HiringDate = DateTime.UtcNow;

            // Создаем сотрудника
            var employeeId = _employeeRepository.CreateAsync(dto, cancellationToken);

            // Отправляем заявку, что сотрудник создан, и нужно выдать мерч

            return employeeId;
        }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Queries;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Employee;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;
using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers.Employees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, GetAllEmployeesQueryResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetAllWithIncludesAsync(cancellationToken);

            return new GetAllEmployeesQueryResponse()
            {
                Items = _mapper.Map<List<EmployeeDto>>(employee)
            };
        }
    }
}

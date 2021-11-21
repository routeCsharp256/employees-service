using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Queries;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Employee;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers
{
    public class GetEmployeesByFilterQueryHandler : IRequestHandler<GetEmployeesByFilterQuery, GetEmployeesByFilterQueryResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEmployeesByFilterQueryHandler> _logger;

        public GetEmployeesByFilterQueryHandler(IEmployeeRepository repository,
            IMapper mapper,
            ILogger<GetEmployeesByFilterQueryHandler> logger = null)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _logger = logger ?? NullLogger<GetEmployeesByFilterQueryHandler>.Instance;
        }

        public async Task<GetEmployeesByFilterQueryResponse> Handle(GetEmployeesByFilterQuery request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<EmployeesFilterDto>(request);
            var result = await _employeeRepository.GetByFilter(dto, cancellationToken);
            return _mapper.Map<GetEmployeesByFilterQueryResponse>(result);
        }
    }
}

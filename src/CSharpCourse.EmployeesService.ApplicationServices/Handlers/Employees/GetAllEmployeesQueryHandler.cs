using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Queries;
using CSharpCourse.EmployeesService.Core.Contracts.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, EmployeesResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllEmployeesQueryHandler> _logger;

        public GetAllEmployeesQueryHandler(IEmployeeRepository repository,
            IMapper mapper,
            ILogger<GetAllEmployeesQueryHandler> logger = null)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _logger = logger ?? NullLogger<GetAllEmployeesQueryHandler>.Instance;
        }

        public async Task<EmployeesResponse> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<EmployeesResponse>(result);
        }
    }
}

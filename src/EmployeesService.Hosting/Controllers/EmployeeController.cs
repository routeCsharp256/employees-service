using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeesService.ApplicationServices.Models.Commands;
using EmployeesService.ApplicationServices.Models.Queries;
using EmployeesService.Hosting.Models.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace EmployeesService.Hosting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IMediator mediator,
            IMapper mapper,
            ILogger<EmployeeController> logger = null)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger ?? NullLogger<EmployeeController>.Instance;
        }

        [HttpGet("getall")]
        public async Task<EmployeesViewModel> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<EmployeesViewModel>(await _mediator.Send(new GetAllEmployeesQuery(), cancellationToken));
        }

        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateEmployeeInputModel viewModel, CancellationToken cancellationToken)
        {
            return await _mediator.Send(_mapper.Map<CreateEmployeeCommand>(viewModel), cancellationToken);
        }
    }
}

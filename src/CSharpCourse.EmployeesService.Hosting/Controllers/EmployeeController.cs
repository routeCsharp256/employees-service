using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Queries;
using CSharpCourse.EmployeesService.PresentationModels.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CSharpCourse.EmployeesService.Hosting.Controllers
{
    [ApiController]
    [Area("employees")]
    [Route("api/[area]")]
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
        public async Task<long> Create([FromBody] CreateEmployeeInputModel value, CancellationToken cancellationToken)
        {
            return await _mediator.Send(_mapper.Map<CreateEmployeeCommand>(value), cancellationToken);
        }

        [HttpPost("toconference")]
        public async Task SendToConference([FromBody] SendToConferenceInputModel value,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(_mapper.Map<SendEmployeeToConferenceCommand>(value), cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Dismiss([FromRoute] long id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DismissEmployeeCommand()
            {
                Id = id
            }, cancellationToken);
        }
    }
}

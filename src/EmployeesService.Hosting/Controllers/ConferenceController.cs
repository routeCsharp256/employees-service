using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeesService.ApplicationServices.Models.Commands;
using EmployeesService.ApplicationServices.Models.Queries;
using EmployeesService.Hosting.Models.Conferences;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace EmployeesService.Hosting.Controllers
{
    [ApiController]
    [Area("conferences")]
    [Route("api/[area]")]
    public class ConferenceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ConferenceController> _logger;

        public ConferenceController(IMediator mediator,
            IMapper mapper,
            ILogger<ConferenceController> logger = null)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger ?? NullLogger<ConferenceController>.Instance;
        }

        [HttpGet("getall")]
        public async Task<ConferencesViewModel> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<ConferencesViewModel>(await _mediator.Send(new GetAllConferencesQuery(), cancellationToken));
        }

        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateConferenceInputModel value, CancellationToken cancellationToken)
        {
            return await _mediator.Send(_mapper.Map<CreateConferenceCommand>(value), cancellationToken);
        }
    }
}

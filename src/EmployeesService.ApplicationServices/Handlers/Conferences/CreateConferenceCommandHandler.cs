using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeesService.ApplicationServices.Models.Commands;
using EmployeesService.Core.Contracts.Repositories;
using EmployeesService.Core.Models.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace EmployeesService.ApplicationServices.Handlers.Conferences
{
    public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand, long>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ILogger<CreateConferenceCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateConferenceCommandHandler(IConferenceRepository repository,
            IMapper mapper,
            ILogger<CreateConferenceCommandHandler> logger = null)
        {
            _conferenceRepository = repository;
            _mapper = mapper;
            _logger = logger ?? NullLogger<CreateConferenceCommandHandler>.Instance;
        }

        public Task<long> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
        {
            return _conferenceRepository.CreateAsync(_mapper.Map<Conference>(request), cancellationToken);
        }
    }
}

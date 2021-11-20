using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.Domain.Contracts.Repositories;
using CSharpCourse.EmployeesService.Domain.Models.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers.Conferences
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
            var dto = _mapper.Map<Conference>(request);
            dto.CreateDate = DateTime.UtcNow;

            return _conferenceRepository.CreateAsync(dto, cancellationToken);
        }
    }
}

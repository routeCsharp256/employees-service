using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpCourse.EmployeesService.ApplicationServices.Models.Commands;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Conference;
using CSharpCourse.EmployeesService.Domain.Contracts;
using CSharpCourse.EmployeesService.Domain.Models.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CSharpCourse.EmployeesService.ApplicationServices.Handlers.Conferences
{
    public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand, long>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateConferenceCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateConferenceCommandHandler(IConferenceRepository repository,
            IMapper mapper, IUnitOfWork unitOfWork, ILogger<CreateConferenceCommandHandler> logger)
        {
            _conferenceRepository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<long> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
        {
            var newConference = Conference.CreateConference(request.Name,
                DateTime.UtcNow,
                request.Date,
                request.Description);

            await _unitOfWork.StartTransaction(cancellationToken);
            var result = await _conferenceRepository.CreateAsync(newConference, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newConference.Id;
        }
    }
}

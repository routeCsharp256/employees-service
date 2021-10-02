using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeesService.ApplicationServices.Models.Queries;
using EmployeesService.Core.Contracts.Repositories;
using MediatR;

namespace EmployeesService.ApplicationServices.Handlers
{
    public class GetAllConferencesQueryHandler : IRequestHandler<GetAllConferencesQuery, ConferencesResponse>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IMapper _mapper;

        public GetAllConferencesQueryHandler(IConferenceRepository conferenceRepository, IMapper mapper)
        {
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
        }

        public async Task<ConferencesResponse> Handle(GetAllConferencesQuery request, CancellationToken cancellationToken)
        {
            var result = await _conferenceRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<ConferencesResponse>(result);
        }
    }
}

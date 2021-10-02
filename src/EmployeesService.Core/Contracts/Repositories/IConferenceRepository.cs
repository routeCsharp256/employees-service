using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmployeesService.Core.Models.Entities;

namespace EmployeesService.Core.Contracts.Repositories
{
    public interface IConferenceRepository : IBaseRepository<Conference, long>
    {
        Task<List<Conference>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default);

        Task<List<Conference>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken = default);

        Task<Conference> CheckIsConferenceIsNotEndAsync(long id, CancellationToken cancellationToken = default);
    }
}

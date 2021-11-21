using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.Domain.Contracts;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Conference
{
    public interface IConferenceRepository : IRepository<Models.Entities.Conference, long>
    {
        Task<List<Models.Entities.Conference>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default);

        Task<List<Models.Entities.Conference>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken = default);

        Task<Models.Entities.Conference> CheckIsConferenceIsNotEndAsync(long id, CancellationToken cancellationToken = default);
    }
}

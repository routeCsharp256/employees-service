using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.Domain.Contracts;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Conference
{
    public interface IConferenceRepository : IRepository<Conference, long>
    {
        Task<List<Conference>> GetAllWithIncludesAsync(CancellationToken cancellationToken);

        Task<List<Conference>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken);

        Task<Conference> CheckIsConferenceIsNotEndAsync(long id, CancellationToken cancellationToken);
    }
}

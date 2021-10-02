using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmployeesService.Core.Models.Entities;

namespace EmployeesService.Core.Contracts.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee, long>
    {
        Task<List<Employee>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default);

        Task<Employee> GetByIdWithIncludesAsync(long id,
            CancellationToken cancellationToken = default);

        Task<List<Employee>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken = default);

        Task<List<long>> GetConferenceIdsAsync(long id, CancellationToken cancellationToken = default);
    }
}

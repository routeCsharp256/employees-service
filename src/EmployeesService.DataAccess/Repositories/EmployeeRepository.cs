using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using EmployeesService.Core.Contracts.Repositories;
using EmployeesService.Core.Models.Entities;
using EmployeesService.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeesService.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, long>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeesDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Employee>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Conferences)
                .ToListAsync(cancellationToken);
        }

        public Task<Employee> GetByIdWithIncludesAsync(long id, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Conferences)
                .FirstOrDefaultAsync(it => it.Id.Equals(id), cancellationToken);
        }

        public Task<List<Employee>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Conferences)
                .Where(it => ids.Contains(it.Id))
                .ToListAsync(cancellationToken);
        }

        public Task<List<long>> GetConferenceIdsAsync(long id, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Where(it => it.Id.Equals(id))
                .SelectMany(it => it.Conferences.Select(c => c.Id))
                .ToListAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.Domain.Models.Entities;
using CSharpCourse.EmployeesService.DataAccess.DbContexts;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Conference;
using Microsoft.EntityFrameworkCore;

namespace CSharpCourse.EmployeesService.DataAccess.Repositories
{
    public class ConferenceRepository : Repository<Conference, long>, IConferenceRepository
    {
        public ConferenceRepository(EmployeesDbContext dbContext) : base(dbContext)
        {

        }

        public Task<List<Conference>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Employees)
                .ToListAsync(cancellationToken);
        }

        public Task<List<Conference>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Employees)
                .Where(it => ids.Contains(it.Id))
                .ToListAsync(cancellationToken);
        }

        public Task<Conference> CheckIsConferenceIsNotEndAsync(long id, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .FirstOrDefaultAsync(it => it.Id == id && it.Date > DateTime.Now, cancellationToken);
        }
    }
}

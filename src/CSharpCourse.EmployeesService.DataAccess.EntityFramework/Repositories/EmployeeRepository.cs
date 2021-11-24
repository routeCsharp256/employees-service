using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.DataAccess.DbContexts;
using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders;
using CSharpCourse.EmployeesService.DataAccess.PredicateBuilders.Base;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Employee;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CSharpCourse.EmployeesService.DataAccess.Repositories
{
    public class EmployeeRepository : Repository<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee,
        long>, IEmployeeRepository
    {
        private readonly IFactory<IEmployeeFilterPredicateBuilder> _filterFactory;

        public EmployeeRepository(EmployeesDbContext dbContext,
            IFactory<IEmployeeFilterPredicateBuilder> filterFactory) : base(dbContext)
        {
            _filterFactory = filterFactory;
        }

        public override Task<List<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee>> GetAllAsync(CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .Where(it => !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public override Task<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .FirstOrDefaultAsync(it => it.Id.Equals(id),
                    cancellationToken);
        }

        public override Task<List<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee>> GetByIdsAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .Where(it => ids.Contains(it.Id) && !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public Task<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .FirstOrDefaultAsync(it => it.Email.Equals(email),
                    cancellationToken);
        }

        public async Task<FilteredEmployeesWithTotalCountDto> GetByFilter(EmployeesFilterDto filter, CancellationToken cancellationToken)
        {
            var predicateBuilder = _filterFactory
                .Create();

            if (filter.FiredDate is not null)
                predicateBuilder.FilterByFiredDates(filter);

            if (filter.HiringDate is not null)
                predicateBuilder.FilterByHiringDates(filter);

            if (filter.ColumnKeywords is not null && filter.ColumnKeywords.Any())
                predicateBuilder.FilterByKeywords(filter);

            predicateBuilder.FilterByStatus(filter);

            var builder = predicateBuilder.Build();
            var query = DbSetNoTracking
                .Where(builder);

            var totalCountResponse = query.CountAsync(cancellationToken);

            //Sorting
            query = query
                .OrderByDescending(x => x.HiringDate);

            //Paging
            query = query
                .Skip((filter.Paging.Page - 1) * filter.Paging.ItemsOnPage)
                .Take(filter.Paging.ItemsOnPage);

            return new FilteredEmployeesWithTotalCountDto
            {
                TotalCount = await totalCountResponse,
                Items = await query.ToListAsync(cancellationToken)
                    .ConfigureAwait(false)
            };
        }

        public Task<List<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee>> GetAllWithIncludesAsync(CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .Include(it => it.EmployeeConferences)
                .ThenInclude(it => it.Conference)
                .Where(it => !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public Task<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee> GetByIdWithIncludesAsync(long id, CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .Include(it => it.EmployeeConferences)
                .ThenInclude(it => it.Conference)
                .FirstOrDefaultAsync(it => it.Id.Equals(id) && !it.IsFired, cancellationToken);
        }

        public Task<List<CSharpCourse.EmployeesService.Domain.Models.Entities.Employee>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .Include(it => it.EmployeeConferences)
                .ThenInclude(it => it.Conference)
                .Where(it => ids.Contains(it.Id) && !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public Task<List<long>> GetConferenceIdsAsync(long id, CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .Where(it => it.Id.Equals(id) && !it.IsFired)
                .SelectMany(it => it.EmployeeConferences.Select(c => c.Conference.Id))
                .ToListAsync(cancellationToken);
        }
    }
}

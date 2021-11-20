using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.Domain.Contracts.Repositories;
using CSharpCourse.EmployeesService.Domain.Models.Entities;
using CSharpCourse.EmployeesService.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CSharpCourse.EmployeesService.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, long>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeesDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Where(it => !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public override Task<Employee> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .FirstOrDefaultAsync(it => it.Id.Equals(id) && !it.IsFired,
                    cancellationToken);
        }

        public override Task<List<Employee>> GetByIdsAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Where(it => ids.Contains(it.Id) && !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public Task<List<Employee>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Conferences)
                .Where(it => !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public Task<Employee> GetByIdWithIncludesAsync(long id, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Conferences)
                .FirstOrDefaultAsync(it => it.Id.Equals(id) && !it.IsFired, cancellationToken);
        }

        public Task<List<Employee>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Include(it => it.Conferences)
                .Where(it => ids.Contains(it.Id) && !it.IsFired)
                .ToListAsync(cancellationToken);
        }

        public Task<List<long>> GetConferenceIdsAsync(long id, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Where(it => it.Id.Equals(id) && !it.IsFired)
                .SelectMany(it => it.Conferences.Select(c => c.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task DismissAsync(long id, CancellationToken cancellationToken = default)
        {
            var employee = await DbSetNoTracking
                .FirstOrDefaultAsync(it => it.Id.Equals(id) && !it.IsFired,
                    cancellationToken);
            if (employee is null)
                throw new Exception($"Employee with id {id} not found or is already fired");

            employee.IsFired = true;
            employee.FiredDate = DateTime.UtcNow;

            Context.Update(employee);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task DismissAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            employee.IsFired = true;
            employee.FiredDate = DateTime.UtcNow;

            Context.Update(employee);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}

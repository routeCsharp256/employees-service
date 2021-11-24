using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.Domain.Models;
using CSharpCourse.EmployeesService.DataAccess.DbContexts;
using CSharpCourse.EmployeesService.Domain.Contracts;
using CSharpCourse.EmployeesService.Domain.Root;
using Microsoft.EntityFrameworkCore;

namespace CSharpCourse.EmployeesService.DataAccess.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected readonly EmployeesDbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IQueryable<TEntity> DbSetNoTracking;

        protected Repository(EmployeesDbContext dbContext)
        {
            Context = dbContext;
            DbSet = dbContext.Set<TEntity>();
            DbSetNoTracking = DbSet.AsNoTracking();
        }

        public virtual Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var added = DbSet.Add(entity);

            return Task.FromResult(added.Entity.Id);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Context.Update(entity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Context.Remove(entity);

            return Task.CompletedTask;
        }

        public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .ToListAsync(cancellationToken);
        }

        public virtual Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .FirstOrDefaultAsync(it => it.Id.Equals(id), cancellationToken);
        }

        public virtual Task<List<TEntity>> GetByIdsAsync(IReadOnlyCollection<TKey> ids, CancellationToken cancellationToken)
        {
            return DbSetNoTracking
                .Where(it => ids.Contains(it.Id))
                .ToListAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeesService.Core.Contracts.Repositories;
using EmployeesService.Core.Models;
using EmployeesService.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeesService.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        protected readonly EmployeesDbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IQueryable<TEntity> DbSetNoTracking;

        protected BaseRepository(EmployeesDbContext dbContext)
        {
            Context = dbContext;
            DbSet = dbContext.Set<TEntity>();
            DbSetNoTracking = DbSet.AsNoTracking();
        }

        public virtual async Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Add(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .ToListAsync(cancellationToken);
        }

        public virtual Task<List<TEntity>> GetByIdsAsync(IReadOnlyCollection<TKey> ids, CancellationToken cancellationToken = default)
        {
            return DbSetNoTracking
                .Where(it => ids.Contains(it.Id))
                .ToListAsync(cancellationToken);
        }
    }
}

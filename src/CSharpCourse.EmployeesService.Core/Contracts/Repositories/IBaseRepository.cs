using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.Core.Models;

namespace CSharpCourse.EmployeesService.Core.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class, IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Create new entry in store
        /// </summary>
        /// <param name="entity">Entry to add</param>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        /// <returns>New identifier of entry</returns>
        Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity to Update</param>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity">Entity to Delete</param>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        /// <returns>Collection of entities</returns>
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Identifier of entity</param>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        /// <returns>Information about entity</returns>
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="ids">Identifier of entity</param>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        /// <returns>Information about entity</returns>
        Task<List<TEntity>> GetByIdsAsync(IReadOnlyCollection<TKey> ids, CancellationToken cancellationToken = default);
    }
}

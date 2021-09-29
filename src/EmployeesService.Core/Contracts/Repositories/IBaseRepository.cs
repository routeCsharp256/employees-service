using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmployeesService.Core.Models;

namespace EmployeesService.Core.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class, IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        /// <returns>Collection of entities</returns>
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="ids">Identifier of entity</param>
        /// <param name="cancellationToken">Token for cancellation operation.</param>
        /// <returns>Information about entity</returns>
        Task<List<TEntity>> GetByIdsAsync(IReadOnlyCollection<TKey> ids, CancellationToken cancellationToken = default);
    }
}
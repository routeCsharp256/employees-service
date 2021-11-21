using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.Domain.Contracts;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Employee
{
    /// <summary>
    /// Репозиторий для управления сущностями сотрудников
    /// </summary>
    public interface IEmployeeRepository : IRepository<Models.Entities.Employee, long>
    {
        Task<List<Models.Entities.Employee>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить данные сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Информация о сотруднике</returns>
        Task<Models.Entities.Employee> GetByIdWithIncludesAsync(long id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить список сотрудников по идентификаторам
        /// </summary>
        /// <param name="ids">Идентификаторы сотрудников</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Список сотрудников</returns>
        Task<List<Models.Entities.Employee>> GetByIdsWithIncludesAsync(IReadOnlyCollection<long> ids,
            CancellationToken cancellationToken = default);

        Task<List<long>> GetConferenceIdsAsync(long id, CancellationToken cancellationToken = default);

        public Task<Models.Entities.Employee> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        public Task<FilteredEmployeesWithTotalCountDto> GetByFilter(EmployeesFilterDto filter,
            CancellationToken cancellationToken = default);
    }
}

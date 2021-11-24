using System;

namespace CSharpCourse.EmployeesService.PresentationModels
{
    /// <inheritdoc cref="IIdModel{TKey}"/>
    public class IdModel<TKey> : IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <inheritdoc cref="Id"/>
        public TKey Id { get; set; }
    }

    /// <summary>
    /// Модель которая содержит идентификатор
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public interface IIdModel<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        TKey Id { get; set; }
    }
}

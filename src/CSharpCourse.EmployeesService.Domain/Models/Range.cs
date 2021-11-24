namespace CSharpCourse.EmployeesService.Domain.Models
{
    /// <summary>
    /// Модель которая представляет даипазон
    /// </summary>
    /// <typeparam name="T">Тип для которого нужен диапазон</typeparam>
    public class Range<T>
    {
        /// <summary>
        /// Значение от
        /// </summary>
        public T From { get; set; }

        /// <summary>
        /// Значение до
        /// </summary>
        public T To { get; set; }
    }
}

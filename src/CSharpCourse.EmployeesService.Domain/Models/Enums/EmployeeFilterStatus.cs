namespace CSharpCourse.EmployeesService.Domain.Models.Enums
{
    /// <summary>
    /// Перечисление по типу сотрудника, текущий или уволенный
    /// </summary>
    public enum EmployeeFilterStatus
    {
        /// <summary>
        /// Все сотрудники
        /// </summary>
        All = 1,

        /// <summary>
        /// Только текущие
        /// </summary>
        Current = 2,

        /// <summary>
        /// Только уволенные
        /// </summary>
        Dismissed = 3
    }
}

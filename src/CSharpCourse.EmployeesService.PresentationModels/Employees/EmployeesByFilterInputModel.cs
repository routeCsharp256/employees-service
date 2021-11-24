using System;
using System.Collections.Generic;
using CSharpCourse.EmployeesService.PresentationModels.Enums;

namespace CSharpCourse.EmployeesService.PresentationModels.Employees
{
    public class EmployeesByFilterInputModel
    {
        /// <summary>
        /// Пагинация
        /// </summary>
        public PaginationFilter Paging { get; set; } = new();

        /// <summary>
        /// Фильтр по дате найма
        /// </summary>
        public Range<DateTime?> HiringDate { get; set; } = null;

        /// <summary>
        /// Фильтр по дате увольнения
        /// </summary>
        public Range<DateTime?> FiredDate { get; set; } = null;

        /// <summary>
        /// Фильтр по типу сотрудников
        /// </summary>
        public EmployeeFilterStatus EmployeeFilterStatus { get; set; } = EmployeeFilterStatus.Current;

        /// <summary>
        /// Фильр по колонкам
        /// </summary>
        public IReadOnlyCollection<ColumnKeywordFilter<EmployeeFilteringColumn>> ColumnKeywords { get; set; } = null;
    }
}

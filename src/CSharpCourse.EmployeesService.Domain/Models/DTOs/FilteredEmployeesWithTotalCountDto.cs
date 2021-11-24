using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Models.Entities;

namespace CSharpCourse.EmployeesService.Domain.Models.DTOs
{
    public class FilteredEmployeesWithTotalCountDto
    {
        /// <summary>
        ///     Total count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        ///     Founded shipments
        /// </summary>
        public IReadOnlyCollection<Employee> Items { get; set; }
    }
}

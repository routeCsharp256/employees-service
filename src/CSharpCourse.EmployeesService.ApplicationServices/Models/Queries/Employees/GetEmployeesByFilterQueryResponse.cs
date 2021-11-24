using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Queries
{
    public class GetEmployeesByFilterQueryResponse
    {
        /// <summary>
        ///     Total count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        ///     Founded shipments
        /// </summary>
        public IReadOnlyCollection<EmployeeDto> Items { get; set; }
    }
}

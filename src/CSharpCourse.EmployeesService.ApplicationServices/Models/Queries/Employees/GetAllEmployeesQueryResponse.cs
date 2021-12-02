using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Queries
{
    public class GetAllEmployeesQueryResponse
    {
        /// <summary>
        ///     Founded Employees
        /// </summary>
        public IReadOnlyCollection<EmployeeDto> Items { get; set; }
    }
}

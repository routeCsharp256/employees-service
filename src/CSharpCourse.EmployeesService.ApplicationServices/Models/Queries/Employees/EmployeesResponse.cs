using System.Collections.Generic;
using CSharpCourse.EmployeesService.Core.Models.DTOs;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Queries
{
    public class EmployeesResponse
    {
        public List<EmployeeDto> Items { get; set; }
    }
}

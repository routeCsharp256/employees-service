using System.Collections.Generic;
using EmployeesService.Core.Models.DTOs;

namespace EmployeesService.ApplicationServices.Models.Queries
{
    public class EmployeesResponse
    {
        public List<EmployeeDto> Items { get; set; }
    }
}

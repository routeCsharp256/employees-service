using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesService.Core.Models.DTOs;

namespace EmployeesService.ApplicationServices.Models.Queries.Employees
{
    public class EmployeesResponse
    {
        public List<EmployeeDto> Items { get; set; }
    }
}
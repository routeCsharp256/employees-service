using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesService.Core.Models;
using EmployeesService.Core.Models.DTOs;
using EmployeesService.Hosting.Models.Conferences;

namespace EmployeesService.Hosting.Models.Employees
{
    public class EmployeeViewModel: IdModel<long>
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Employee birth day
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Date of hiring
        /// </summary>
        public DateTime HiringDate { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }
    }
}
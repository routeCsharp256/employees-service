using System;
using System.ComponentModel.DataAnnotations;

namespace CSharpCourse.EmployeesService.Hosting.Models.Employees
{
    public class CreateEmployeeInputModel
    {
        /// <summary>
        /// First name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Middle name
        /// </summary>
        [Required]
        public string MiddleName { get; set; }

        /// <summary>
        /// Employee birth day
        /// </summary>
        [Required]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

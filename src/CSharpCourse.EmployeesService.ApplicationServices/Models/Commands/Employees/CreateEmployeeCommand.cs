using System;
using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Commands
{
    public class CreateEmployeeCommand : IRequest<long>
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
        /// Email address
        /// </summary>
        public string Email { get; set; }
    }
}

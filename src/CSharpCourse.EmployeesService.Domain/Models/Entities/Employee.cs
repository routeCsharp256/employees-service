using System;
using System.Collections.Generic;

namespace CSharpCourse.EmployeesService.Domain.Models.Entities
{
    /// <summary>
    /// Employee of company
    /// </summary>
    public class Employee : IdModel<long>
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

        /// <summary>
        /// Date of hiring
        /// </summary>
        public DateTime HiringDate { get; set; }

        /// <summary>
        /// Является ли сотрудник уволеным
        /// </summary>
        public bool IsFired { get; set; }

        /// <summary>
        /// Дата увольнения сотрудника
        /// </summary>
        public DateTime? FiredDate { get; set; }

        public int ClothingSize { get; set; }

        /// <summary>
        /// Conferences that an employee can attend
        /// </summary>
        public ICollection<Conference> Conferences { get; set; }
    }
}

using System;
using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.AggregationModels;
using CSharpCourse.EmployeesService.Domain.AggregationModels.Conference;
using CSharpCourse.EmployeesService.Domain.Root;

namespace CSharpCourse.EmployeesService.Domain.Models.Entities
{
    /// <summary>
    /// Employee of company
    /// </summary>
    public class Employee : Entity<long>
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

        /// <summary>
        /// Размер одежды
        /// </summary>
        public int ClothingSize { get; set; }

        public ICollection<EmployeeConference> EmployeeConferences { get; set; }
    }
}

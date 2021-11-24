using System;
using System.ComponentModel.DataAnnotations;
using CSharpCourse.EmployeesService.PresentationModels.Enums;

namespace CSharpCourse.EmployeesService.PresentationModels.Employees
{
    /// <summary>
    /// Модель для создания нового сотрудника
    /// </summary>
    public sealed class CreateEmployeeInputModel : IEmployeeModel
    {
        /// <inheritdoc cref="FirstName"/>
        [Required]
        public string FirstName { get; set; }

        /// <inheritdoc cref="LastName"/>
        [Required]
        public string LastName { get; set; }

        /// <inheritdoc cref="MiddleName"/>
        [Required]
        public string MiddleName { get; set; }

        /// <inheritdoc cref="BirthDay"/>
        [Required]
        public DateTime BirthDay { get; set; }

        /// <inheritdoc cref="Email"/>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <inheritdoc cref="ClothingSize"/>
        public ClothingSize ClothingSize { get; set; }
    }
}

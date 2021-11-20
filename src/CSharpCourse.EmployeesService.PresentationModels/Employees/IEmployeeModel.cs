using System;
using CSharpCourse.EmployeesService.PresentationModels.Enums;

namespace CSharpCourse.EmployeesService.PresentationModels.Employees
{
    public interface IEmployeeModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// День рождения сотрудника
        /// </summary>
        DateTime BirthDay { get; set; }

        /// <summary>
        /// Email адрес
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Размер одежды
        /// </summary>
        ClothingSize ClothingSize { get; set; }
    }
}

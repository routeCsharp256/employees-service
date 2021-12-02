using System;
using System.Collections.Generic;
using CSharpCourse.EmployeesService.PresentationModels.Conferences;
using CSharpCourse.EmployeesService.PresentationModels.Enums;

namespace CSharpCourse.EmployeesService.PresentationModels.Employees
{
    public sealed class EmployeeViewModel: IdModel<long>, IEmployeeModel
    {
        /// <inheritdoc cref="FirstName"/>
        public string FirstName { get; set; }

        /// <inheritdoc cref="LastName"/>
        public string LastName { get; set; }

        /// <inheritdoc cref="MiddleName"/>
        public string MiddleName { get; set; }

        /// <inheritdoc cref="BirthDay"/>
        public DateTime BirthDay { get; set; }

        /// <inheritdoc cref="HiringDate"/>
        public DateTime HiringDate { get; set; }

        /// <inheritdoc cref="Email"/>
        public string Email { get; set; }

        /// <inheritdoc cref="ClothingSize"/>
        public ClothingSize ClothingSize { get; set; }

        /// <summary>
        /// Список конференций на которые был записан сотрудник
        /// </summary>
        public IReadOnlyCollection<ConferenceViewModel> Conferences { get; set; }
    }
}

using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Root;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Employee
{
    /// <summary>
    /// ValueObject для описания полного имени сотрудника
    /// </summary>
    public class FullName : ValueObject
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; }

        public FullName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
        }
    }
}

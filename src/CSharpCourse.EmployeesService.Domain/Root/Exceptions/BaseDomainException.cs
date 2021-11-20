using System;

namespace CSharpCourse.EmployeesService.Domain.Root.Exceptions
{
    /// <summary>
    /// Общее доменное исключение
    /// </summary>
    [Serializable]
    public class BaseDomainException : Exception
    {
        public BaseDomainException()
        {
        }

        public BaseDomainException(string description)
            : base(description)
        {
        }

        public BaseDomainException(string description, Exception innerException)
            : base(description, innerException)
        {
        }
    }
}

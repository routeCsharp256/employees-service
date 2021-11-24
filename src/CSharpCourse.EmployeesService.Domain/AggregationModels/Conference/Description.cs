using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Root;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Conference
{
    public class Description : ValueObject
    {
        public string Value { get; private set; }

        public Description() { }

        public Description(string description)
        {
            Value = description;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

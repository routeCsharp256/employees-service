using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Root;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Conference
{
    public class Name : ValueObject
    {
        public string Value { get; private set; }

        public Name() { }

        public Name(string name)
        {
            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

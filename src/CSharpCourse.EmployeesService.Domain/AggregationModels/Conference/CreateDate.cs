using System;
using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Root;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Conference
{
    public class CreateDate : ValueObject
    {
        public DateTime Value { get; private set; }

        public CreateDate() { }

        public CreateDate(DateTime createDate)
        {
            Value = createDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

using System;
using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Root;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Conference
{
    public class ConferenceDate : ValueObject
    {
        public DateTime Value { get; private set; }

        public ConferenceDate() { }

        public ConferenceDate(DateTime conferenceDate)
        {
            Value = conferenceDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

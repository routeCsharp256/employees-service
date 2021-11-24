namespace CSharpCourse.EmployeesService.Domain.AggregationModels
{
    public class EmployeeConference
    {
        public long EmployeeId { get; set; }
        public long ConferenceId { get; set; }

        public Conference.Conference Conference { get; set; }
        public Models.Entities.Employee Employee { get; set; }
    }
}

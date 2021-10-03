namespace CSharpCourse.EmployeesService.ApplicationServices.Configurations
{
    public class KafkaConfiguration
    {
        /// <summary>
        /// Collection of bootstrap services
        /// </summary>
        public string BootstrapServers { get; set; }

        /// <summary>
        /// Topic for create new employee event
        /// </summary>
        public string CreateNewEmployeeTopic { get; set; }

        /// <summary>
        /// Topic for dismiss employee event
        /// </summary>
        public string DismissEmployeeTopic { get; set; }

        /// <summary>
        /// Topic for send employee to conference
        /// </summary>
        public string MoveToConferenceTopic { get; set; }
    }
}

namespace CSharpCourse.EmployeesService.ApplicationServices.Configurations
{
    public class KafkaConfiguration
    {
        /// <summary>
        /// Collection of bootstrap service
        /// </summary>
        public string BootstrapServer { get; set; }

        /// <summary>
        /// Topic for create new employee event
        /// </summary>
        public string Topic { get; set; }
    }
}

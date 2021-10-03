using Confluent.Kafka;

namespace CSharpCourse.EmployeesService.ApplicationServices.MessageBroker
{
    public interface IProducerBuilderWrapper
    {
        /// <summary>
        /// Producer instance
        /// </summary>
        IProducer<string, string> Producer { get; set; }

        /// <summary>
        /// Topic for create new employee event
        /// </summary>
        string CreateNewEmployeeTopic { get; set; }

        /// <summary>
        /// Topic for dismiss employee event
        /// </summary>
        string DismissEmployeeTopic { get; set; }

        /// <summary>
        /// Topic for send employee to conference
        /// </summary>
        string MoveToConferenceTopic { get; set; }
    }
}

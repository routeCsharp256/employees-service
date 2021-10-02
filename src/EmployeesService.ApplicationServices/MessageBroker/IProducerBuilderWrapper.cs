using Confluent.Kafka;

namespace EmployeesService.ApplicationServices.MessageBroker
{
    public interface IProducerBuilderWrapper
    {
        /// <summary>
        /// Producer instance
        /// </summary>
        public IProducer<string, string> Producer { get; set; }

        /// <summary>
        /// Topic for create new employee event
        /// </summary>
        public string CreateNewEmployeeTopic { get; set; }

        /// <summary>
        /// Topic for send employee to conference
        /// </summary>
        public string MoveToConferenceTopic { get; set; }
    }
}

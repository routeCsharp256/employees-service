using MediatR;
using CSharpCourse.EmployeesService.ApplicationServices.Models;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Commands
{
    public class SendEmployeeToConferenceCommand : IRequest
    {
        /// <summary>
        /// Идентификатор сотрудника которого отправляют на конференцию
        /// </summary>
        /// <value></value>
        public long EmployeeId { get; set; }
        /// <summary>
        /// Идентификатор конференции на которую отправляют
        /// </summary>
        /// <value></value>
        public long ConferenceId { get; set; }
        /// <summary>
        /// В качестве кого будет сотрудник отправлен, либо слушатель либо докладчик
        /// </summary>
        /// <value></value>
        public int AsWhom { get; set; }
    }
}

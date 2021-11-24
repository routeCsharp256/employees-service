using CSharpCourse.EmployeesService.PresentationModels.Enums;

namespace CSharpCourse.EmployeesService.PresentationModels.Employees
{
    public sealed class SendToConferenceInputModel
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
        public EmployeeInConferenceType AsWhom { get; set; }
    }
}

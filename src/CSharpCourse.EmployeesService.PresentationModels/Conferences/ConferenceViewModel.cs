using System;

namespace CSharpCourse.EmployeesService.PresentationModels.Conferences
{
    public sealed class ConferenceViewModel : IdModel<long>
    {
        /// <summary>
        /// Name of conference
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date of the conference
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Conference description
        /// </summary>
        public string Description { get; set; }
    }
}

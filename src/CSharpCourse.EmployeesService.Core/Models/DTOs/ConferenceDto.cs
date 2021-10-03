using System;
using System.Collections.Generic;

namespace CSharpCourse.EmployeesService.Core.Models.DTOs
{
    public class ConferenceDto : IdModel<long>
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

        /// <summary>
        /// Employees that went to conference
        /// </summary>
        public ICollection<EmployeeDto> Employees { get; set; }
    }
}

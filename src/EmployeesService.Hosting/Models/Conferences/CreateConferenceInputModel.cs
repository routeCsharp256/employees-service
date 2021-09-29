using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeesService.Hosting.Models.Conferences
{
    public class CreateConferenceInputModel
    {
        /// <summary>
        /// Name of conference
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Date of the conference
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Conference description
        /// </summary>
        public string Description { get; set; }
    }
}

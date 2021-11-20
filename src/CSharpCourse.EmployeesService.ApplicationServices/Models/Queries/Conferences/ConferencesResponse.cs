using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Models.DTOs;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Queries
{
    /// <summary>
    /// Conferences collection
    /// </summary>
    public class ConferencesResponse
    {
        /// <summary>
        /// Conference items
        /// </summary>
        public List<ConferenceDto> Items { get; set; }
    }
}

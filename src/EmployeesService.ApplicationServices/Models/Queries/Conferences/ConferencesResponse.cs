using System.Collections.Generic;
using EmployeesService.Core.Models.DTOs;

namespace EmployeesService.ApplicationServices.Models.Queries
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

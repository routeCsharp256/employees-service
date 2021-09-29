using System;
using MediatR;

namespace EmployeesService.ApplicationServices.Models.Commands
{
    public class CreateConferenceCommand : IRequest<long>
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

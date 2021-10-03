﻿using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Commands
{
    public class SendEmployeeToConferenceCommand : IRequest
    {
        public long EmployeeId { get; set; }
        public long ConferenceId { get; set; }
    }
}
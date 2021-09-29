using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace EmployeesService.ApplicationServices.Models.Queries.Employees
{
    public class GetAllEmployeesQuery : IRequest<EmployeesResponse>
    {
        // empty
    }
}
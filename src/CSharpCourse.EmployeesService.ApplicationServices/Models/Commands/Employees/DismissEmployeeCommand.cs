using CSharpCourse.EmployeesService.Core.Models;
using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Commands
{
    public class DismissEmployeeCommand : IdModel<long>, IRequest
    {

    }
}

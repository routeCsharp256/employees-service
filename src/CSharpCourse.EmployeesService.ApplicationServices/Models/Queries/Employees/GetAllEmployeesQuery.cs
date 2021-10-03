using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Queries
{
    public class GetAllEmployeesQuery : IRequest<EmployeesResponse>
    {
        // empty
    }
}

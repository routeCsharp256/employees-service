using MediatR;

namespace EmployeesService.ApplicationServices.Models.Queries
{
    public class GetAllEmployeesQuery : IRequest<EmployeesResponse>
    {
        // empty
    }
}

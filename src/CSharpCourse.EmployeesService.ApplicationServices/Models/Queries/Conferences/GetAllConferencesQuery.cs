using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Queries
{
    /// <summary>
    /// Get All conferences
    /// </summary>
    public class GetAllConferencesQuery : IRequest<ConferencesResponse>
    {
        // empty
    }
}

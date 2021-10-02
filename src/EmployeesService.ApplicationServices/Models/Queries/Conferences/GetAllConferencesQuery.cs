using MediatR;

namespace EmployeesService.ApplicationServices.Models.Queries
{
    /// <summary>
    /// Get All conferences
    /// </summary>
    public class GetAllConferencesQuery : IRequest<ConferencesResponse>
    {
        // empty
    }
}

using CSharpCourse.Core.Lib.Models;
using MediatR;

namespace CSharpCourse.EmployeesService.ApplicationServices.Models.Queries
{
    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    public class GetEmployeeByIdQuery : IIdModel<long>, IRequest<GetEmployeeByIdQueryResponse>
    {
        public long Id { get; set; }
    }
}

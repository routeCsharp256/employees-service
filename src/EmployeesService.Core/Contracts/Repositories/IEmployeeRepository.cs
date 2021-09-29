using EmployeesService.Core.Models.Entities;

namespace EmployeesService.Core.Contracts.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeDto, long>
    {
        
    }
}
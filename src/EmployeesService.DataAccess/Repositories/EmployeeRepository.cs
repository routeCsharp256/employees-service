using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmployeesService.Core.Contracts.Repositories;
using EmployeesService.Core.Models.Entities;
using EmployeesService.DataAccess.DbContexts;

namespace EmployeesService.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, long>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeesDbContext dbContext) : base(dbContext)
        {

        }

        public override Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Employee>> GetByIdsAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

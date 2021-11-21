using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCourse.EmployeesService.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ValueTask StartTransaction(CancellationToken token);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

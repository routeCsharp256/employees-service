using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.EmployeesService.DataAccess.DbContexts;
using CSharpCourse.EmployeesService.DataAccess.Exceptions;
using CSharpCourse.EmployeesService.Domain.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace CSharpCourse.EmployeesService.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeesDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EmployeesDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async ValueTask StartTransaction(CancellationToken token)
        {
            if (_transaction is not null)
            {
                return;
            }
            _transaction = await _context.Database.BeginTransactionAsync(token);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (_transaction is null)
            {
                throw new NoActiveTransactionStartedException();
            }

            // var domainEvents = new Queue<INotification>(
            //     _changeTracker.TrackedEntities
            //         .SelectMany(x =>
            //         {
            //             var events = x.DomainEvents.ToList();
            //             x.ClearDomainEvents();
            //             return events;
            //         }));
            // // Можно отправлять все и сразу через Task.WhenAll.
            // while (domainEvents.TryDequeue(out var notification))
            // {
            //     await _publisher.Publish(notification, cancellationToken);
            // }

            var savedCount = await _context.SaveChangesAsync(cancellationToken);

            await _transaction.CommitAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using MediatR;

namespace CSharpCourse.EmployeesService.Domain.Root
{
    public abstract class Entity<TKey>
        where TKey : IEquatable<TKey>
    {
        private int? _requestedHashCode;

        public virtual TKey Id { get; protected set; }

        private readonly List<INotification> _domainEvents = new();

        public IReadOnlyCollection<INotification> DomainEvents
            => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
            => _domainEvents.Add(eventItem);

        public void RemoveDomainEvent(INotification eventItem)
            => _domainEvents.Remove(eventItem);

        public void ClearDomainEvents()
            => _domainEvents.Clear();

        public bool IsTransient()
            => Id.Equals(default(TKey));

        public override bool Equals(object obj)
        {
            if (obj is not Entity<TKey> entity)
                return false;

            if (ReferenceEquals(this, entity))
                return true;

            if (GetType() != entity.GetType())
                return false;

            if (entity.IsTransient() || IsTransient())
                return false;
            else
                return entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                _requestedHashCode ??= HashCode.Combine(Id, 31);

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return left?.Equals(right) ?? object.Equals(right, null);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }
}

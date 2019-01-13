using System.Collections.Generic;

namespace Tactical.DDD
{
    public abstract class AggregateRoot<TIdentity> : Entity<TIdentity>
        where TIdentity : IDomainIdentity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        
        protected AggregateRoot() {}

        protected void AddDomainEvent(IDomainEvent @event) =>
            _domainEvents.Add(@event);

        protected void RemoveDomainEvent(IDomainEvent @event) =>
            _domainEvents.Remove(@event);

        // public?
        protected void ClearDomainEvents() =>
            _domainEvents.Clear();
        
        public IReadOnlyCollection<IDomainEvent> DomainEvents => 
            _domainEvents.AsReadOnly();
    }
}
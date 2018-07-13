using System.Threading;
using System.Threading.Tasks;
using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.SharedKernel;
using NHibernate.Event;

namespace DDDInPractice.Logic.Utils
{
    internal class EventListener:
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
    {
        public async Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }


        public async Task OnPostDeleteAsync(PostDeleteEvent @event, CancellationToken cancellationToken)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostDelete(PostDeleteEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public async Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }


        public async Task OnPostUpdateCollectionAsync(PostCollectionUpdateEvent @event, CancellationToken cancellationToken)
        {
            DispatchEvents(@event.AffectedOwnerIdOrNull as AggregateRoot);
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent @event)
        {
            DispatchEvents(@event.AffectedOwnerIdOrNull as AggregateRoot);
        }

        private void DispatchEvents(AggregateRoot aggregateRoot)
        {
            foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
            {
                DomainEvents.Dispatch(domainEvent);
            }

            aggregateRoot.ClearEvents();
        }

        //private async Task DispatchEventsAsync(AggregateRoot aggregateRoot)
        //{
        //    foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
        //    {
        //        DomainEvents.Dispatch(domainEvent);
        //    }

        //    aggregateRoot.ClearEvents();
        //}
    }
}
namespace SimpleEventSourcing.Models
{
    using System;
    using System.Collections.Generic;
    using Events;

    public abstract class AggregateRoot
    {
        private List<Event> events;
        private Dictionary<Type, Action<object>> handlers;
        public Guid Id;

        protected AggregateRoot()
        {
            events = new List<Event>();
            handlers = new Dictionary<Type, Action<object>>();
        }

        protected void Register<T>(Action<T> when)
        {
            handlers.Add(typeof(T), e => when((T) e));
        }

        public void Apply(Event @event)
        {
            handlers[@event.GetType()](@event);
        }

        protected void Raise(Event @event)
        {
            events.Add(@event);

            Apply(@event);
        }

        public List<Event> GetEvents()
        {
            return events;
        }
    }
}
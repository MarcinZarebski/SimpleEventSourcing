namespace SimpleEventSourcing.Events
{
    using System;

    public class Event
    {
        public Guid AggregateRootId { get; }

        public DateTime CreateDateTime { get; }

        protected Event(Guid aggregateRootId)
        {
            AggregateRootId = aggregateRootId;
            CreateDateTime = DateTime.Now;
        }
    }
}
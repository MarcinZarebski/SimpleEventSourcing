namespace SimpleEventSourcing.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Events;

    public interface IPublisher
    {
        Task Publish(Event @event);
        Task Publish(IEnumerable<Event> events);
    }
}
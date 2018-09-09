namespace SimpleEventSourcing.EventHandlers
{
    using Events;
    using Repositories;

    public class EventHandler
    {
        protected IEventRepository EventRepository;

        public EventHandler(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }

        public void Save(Event @event)
        {
            EventRepository.Save(@event);
        }
    }
}
namespace SimpleEventSourcing.Repositories
{
    using Events;

    public interface IEventRepository
    {
        void Save(Event @event);
    }
}

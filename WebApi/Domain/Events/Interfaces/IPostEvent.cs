namespace Domain.Events.Interfaces
{
    public interface IPostEvent
    {
        public IEvent Execute(Event @event);
    }
}

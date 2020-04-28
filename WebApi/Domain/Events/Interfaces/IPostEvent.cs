using Domain.Interfaces;

namespace Domain.Events.Interfaces
{
    public interface IPostEvent
    {
        public IEvent Execute(IEvent @event);

    }
}

using System;

namespace Domain.Events
{
    public interface IEventFactory
    {
        public IEvent CreateEvent(string name, string description, DateTime stardDate);
    }
}

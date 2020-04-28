using Domain.Events;
using System;

namespace Infrastructure
{
    public class EventFactory : IEventFactory
    {
        public IEvent CreateEvent(string name, string description, DateTime stardDate)
        {
            return new Entities._Event(name, description, stardDate);
        }
    }
}

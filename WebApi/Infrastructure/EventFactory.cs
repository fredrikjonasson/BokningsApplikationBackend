using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

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

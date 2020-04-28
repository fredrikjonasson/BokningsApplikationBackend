using Domain.Invitations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class EventFactory : IEventFactory
    {
        public IEvent CreateEvent(string name, string description, DateTime startDate)
        {
            Event @event = new Event() { 
                Name = name,
                Description = description,
                StartDate = startDate
            };
            return @event;
        }
    }
}

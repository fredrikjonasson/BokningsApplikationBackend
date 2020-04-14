using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Interfaces
{
    public interface IPostEvent
    {
        public Event Execute(Event @event);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Interfaces
{
    public interface IGetEvent
    {
        public Event Execute(Guid id);
    }
}

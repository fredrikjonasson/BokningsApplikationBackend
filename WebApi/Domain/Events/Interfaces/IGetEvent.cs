using System;

namespace Domain.Events.Interfaces
{
    public interface IGetEvent
    {
        public IEvent Execute(Guid id);
    }
}

using System;

namespace Domain.Events
{
    public interface IEventRespository
    {
        IEvent GetById(Guid id);
    }
}
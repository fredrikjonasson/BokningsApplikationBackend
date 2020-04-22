using System;

namespace Domain.Events
{
    public interface IEvent
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
    }
}
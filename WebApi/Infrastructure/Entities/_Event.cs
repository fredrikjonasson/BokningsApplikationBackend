using System;
using System.Collections.Generic;
using Domain.Events;

namespace Infrastructure.Entities
{
    public class _Event : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public List<Invitation> SentInvitations { get; set; }

        public _Event(string name, string description, DateTime startDate)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            SentInvitations = new List<Invitation>();
        }
    }
}

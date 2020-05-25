using System;

namespace Infrastructure.Entities
{
    public class Participant : Domain.Participants.Participant
    {
        public Event Event { get; set; }
        public Guid EventId { get; set; }
    }
}

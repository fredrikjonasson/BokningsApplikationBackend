using Domain.Invitations;
using Domain.Participants;
using System;
using System.Collections.Generic;

namespace Domain.Events
{
    public class Event : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public List<Invitation> SentInvitations { get; set; }
        public List<Participant> Participants { get; set; }

        public Event()
        {
            SentInvitations = new List<Invitation>();
        }
    }
}

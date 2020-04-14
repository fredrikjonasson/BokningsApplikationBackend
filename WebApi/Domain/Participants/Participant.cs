using Domain.Participants.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Participants
{
    public class Participant : IParticipant
    {
        public Guid Id { get; set; }
        public IContactInformation ContactInformation { get; set; }
    }
}

using Domain.Participants.Interfaces;
using System;

namespace Domain.Participants
{
    public class Participant : IParticipant
    {
        public Guid Id { get; set; }
        public IContactInformation ContactInformation { get; set; }
    }
}

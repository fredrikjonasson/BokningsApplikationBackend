using Domain.Participants.Interfaces;
using System;

namespace Domain.Participants
{
    public abstract class Participant : IParticipant
    {
        public Guid Id { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}

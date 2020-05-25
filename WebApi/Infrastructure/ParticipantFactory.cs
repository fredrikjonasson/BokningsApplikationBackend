using Domain.Participants;
using Domain.Participants.Interfaces;
using System;

namespace Infrastructure
{
    public class ParticipantFactory : IParticipantFactory
    {
        public IParticipant CreateParticipant(Guid eventId, ContactInformation contact)
        {
            var participant = new Infrastructure.Entities.Participant
            { 
                ContactInformation = contact,
                EventId = eventId
            };
            return participant;
        }
    }
}

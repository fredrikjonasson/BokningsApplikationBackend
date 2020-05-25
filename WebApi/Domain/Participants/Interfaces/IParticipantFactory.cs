using System;

namespace Domain.Participants.Interfaces
{
    public interface IParticipantFactory
    {
        public IParticipant CreateParticipant(Guid eventId, ContactInformation contactInformation);
    }
}

using Domain.Events;
using Domain.Invitations;
using System;

namespace Infrastructure
{
    public class EntitiesFactory : IEventFactory, IInvitationFactory
    {
        public IEvent CreateEvent(string name, string description, DateTime stardDate, IInvitationFactory _iInvitationFactory)
        {
            return new Entities._Event(name, description, stardDate);
        }

        public IInvitation CreateInvite(string email, Guid eventId) => new Entities.Invitation(email, eventId);
    }
}

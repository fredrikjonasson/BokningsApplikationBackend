using Domain.Invitations;
using System;

namespace Infrastructure
{
    public class InvitationFactory : IInvitationFactory
    {
        public IInvitation CreateInvite(string email, Guid eventId) => new Entities.Invitation(email, eventId);
    }
}

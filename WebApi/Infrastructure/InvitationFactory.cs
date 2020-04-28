using Domain.Invitations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class InvitationFactory : IInvitationFactory
    {
        public IInvitation CreateInvite(string email, Guid eventId) => new Entities.Invitation(email, eventId);
    }
}

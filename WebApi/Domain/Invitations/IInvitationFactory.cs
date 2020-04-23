using System;

namespace Domain.Invitations
{
    public interface IInvitationFactory
    {
        IInvitation CreateInvite(string email, Guid eventId);
    }
}

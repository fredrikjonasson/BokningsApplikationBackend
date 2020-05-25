using System;

namespace Domain.Invitations
{
    public interface IInvitationRepository
    {
        IInvitation GetById(Guid id);
    }
}
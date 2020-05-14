using System;

namespace Domain.Invitations
{
    public interface IInvitation
    {
        public Guid Id {get; set;}
        public string Email {get; set;}
        public InvitationStatus InvitationStatus {get; set;}
    }
}

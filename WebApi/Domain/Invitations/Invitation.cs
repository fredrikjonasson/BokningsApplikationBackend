using System;
namespace Domain.Invitations
{
    public class Invitation : IInvitation
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public string Email { get; set; }
        public InvitationStatus InvitationStatus { get; set; }
    }
}

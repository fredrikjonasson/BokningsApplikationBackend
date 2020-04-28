
using Domain.Invitations;
using System;

namespace Infrastructure.Entities
{
    public class Invitation : IInvitation
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Answered { get; set; }
        public Guid _EventId { get; set; }

        public Invitation(string email, Guid eventId)
        {
            Email = email;
            _EventId = eventId;
        }
    }
}

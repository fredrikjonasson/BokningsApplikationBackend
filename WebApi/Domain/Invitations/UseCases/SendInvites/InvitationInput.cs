using System;
using System.Collections.Generic;

namespace Domain.Invitations.UseCases
{
    public class InvitationInput
    {
        public List<string> Emails { get; set; }
        public Guid EventId { get; set; }

        public InvitationInput(List<string> emails, Guid eventId)
        {
            Emails = emails;
            EventId = eventId;
        }
    }
}

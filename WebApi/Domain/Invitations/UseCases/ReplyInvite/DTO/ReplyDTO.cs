using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Domain.Invitations.UseCases.ReplyInvite
{
    public class ReplyDTO
    {
        public Guid Id { get; set; }
        public bool Answer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ReplyDTO(Guid id, bool Answer)
        {

        }
    }
}

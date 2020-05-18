using Domain.Invitations.UseCases.ReplyInvite;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Domain.Participants.Interfaces
{
    public interface IParticipantFactory
    {
        public Participant CreateParticipant(ReplyDTO replyDTO);
    }
}

using Domain.Events;
using Domain.Interfaces;
using Domain.Invitations.UseCases.ReplyInvite;
using Domain.Participants;
using Domain.Participants.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Invitations.UseCases
{
    public class ReplyUseCase : IUseCase<ReplyDTO>
    {
        public DbContext _eventContext { get; set; }
        public IParticipantFactory _participantFactory { get; set; }

        public ReplyUseCase(DbContext eventContext, IParticipantFactory participantFactory)
        {
            _eventContext = eventContext;
            _participantFactory = participantFactory;
        }

        public void Execute(ReplyDTO replyDTO)
        {
            Invitation invitation = _eventContext.Find<Invitation>(replyDTO.Id);
            Event @event = _eventContext.Find<Event>(invitation.EventId);
            invitation.Reply(replyDTO.Answer);

            if (invitation.InvitationStatus == InvitationStatus.Accepted)
            {
                _participantFactory.CreateParticipant(replyDTO)
            }



        }
    }
}

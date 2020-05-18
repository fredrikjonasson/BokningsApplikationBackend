using Domain.Invitations.UseCases.ReplyInvite;
using Domain.Participants;
using Domain.Participants.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ParticipantFactory : IParticipantFactory
    {
        public Participant CreateParticipant(ReplyDTO replyDTO)
        {
            ContactInformation contactInformation = new ContactInformation
            {
                FirstName = replyDTO.FirstName,
                LastName = replyDTO.LastName,
                Email = replyDTO.Email
            };

            Participant participant = new Participant { ContactInformation = contactInformation };
            return participant;
        }
    }
}

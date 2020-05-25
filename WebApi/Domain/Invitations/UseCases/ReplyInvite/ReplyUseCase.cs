using Domain.Events;
using Domain.Interfaces;
using Domain.Invitations.UseCases.ReplyInvite;
using Domain.Participants;
using Domain.Participants.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Domain.Invitations.UseCases
{
    public class ReplyUseCase : IUseCase<ReplyDTO>
    {
        private readonly DbContext _eventContext;
        private readonly IParticipantFactory _participantFactory;
        private readonly IEventRespository _eventRespository;
        private readonly IInvitationRepository _invitationRepository;

        public ReplyUseCase(DbContext eventContext, IParticipantFactory participantFactory, IEventRespository eventRespository, IInvitationRepository invitationRepository)
        {
            _eventContext = eventContext;
            _participantFactory = participantFactory;
            _eventRespository = eventRespository;
            _invitationRepository = invitationRepository;
        }

        public void Execute(ReplyDTO replyDto)
        {
            var invitation = _invitationRepository.GetById(replyDto.Id);
            var @event = _eventRespository.GetById(invitation.EventId);

            invitation.Reply(replyDto.Answer);

            if (invitation.InvitationStatus == InvitationStatus.Accepted)
            {
                _eventContext.Add(_participantFactory.CreateParticipant(invitation.EventId, new ContactInformation { Email = replyDto.Email, FirstName = replyDto.FirstName, LastName = replyDto.LastName}));
            }
            _eventContext.Update(invitation);
            _eventContext.SaveChanges();
        }
    }
}

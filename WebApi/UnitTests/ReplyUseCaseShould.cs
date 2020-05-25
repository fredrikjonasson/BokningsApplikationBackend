using Domain.Events;
using Domain.Invitations;
using Domain.Invitations.UseCases;
using Domain.Invitations.UseCases.ReplyInvite;
using Domain.Participants.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class ReplyUseCaseShould
    {
        private EventContext _context;
        private readonly IParticipantFactory _participantFactory;
        private readonly IEventRespository _eventRepository;
        private readonly IInvitationRepository _invitationRepository;
        private Guid invitationTestGuid = Guid.NewGuid();
        private Guid eventTestGuid = Guid.NewGuid();

        public ReplyUseCaseShould()
        {
            SetupContext();
            _participantFactory = new ParticipantFactory();
            _invitationRepository = new InvitationRepository(_context);
            _eventRepository = new EventRepository(_context);
        }

        private void SetupContext()
        {
            var options = new DbContextOptionsBuilder<EventContext>()
                    .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                    .Options;
            _context = new EventContext(options);
        }

        private void PopulateContext()
        {
            var testInvitation = new Infrastructure.Entities.Invitation("testemail", eventTestGuid)
            {
                InvitationStatus = InvitationStatus.Accepted,
                Id = invitationTestGuid
            };

            DateTime dateTime = DateTime.Now;
            Infrastructure.Entities.Event @event = new Infrastructure.Entities.Event("testeventname", "testeventdesc", dateTime);
            @event.Id = eventTestGuid;
            @event.SentInvitations.Add(testInvitation);


            _context.Add(@event);
            _context.SaveChanges();
        }

        [Fact]
        public void AddParticipantWhenInviteAccepted()
        {
            PopulateContext();
            var testUseCase = new ReplyUseCase(_context, _participantFactory, _eventRepository, _invitationRepository);
            testUseCase.Execute(new ReplyDTO(invitationTestGuid, true));

            var @event = _context.Find<Infrastructure.Entities.Event>(eventTestGuid);
            var invitation = _context.Find<Infrastructure.Entities.Invitation>(invitationTestGuid);
            var par = _context.Participants.ToList();
            Assert.Equal(InvitationStatus.Accepted, invitation.InvitationStatus);
            Assert.NotEmpty(@event.Participants);
        }

    }
}

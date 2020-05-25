using Domain.Events;
using Domain.Invitations;
using Domain.Invitations.UseCases;
using Domain.Invitations.UseCases.ReplyInvite;
using Domain.Participants.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class ReplyUseCaseShould
    {
        private EventContext _context;
        private readonly IParticipantFactory participantFactory;
        private Guid invitationTestGuid = Guid.NewGuid();
        private Guid eventTestGuid = Guid.NewGuid();

        public ReplyUseCaseShould()
        {
            SetupContext();
            participantFactory = new ParticipantFactory();
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
            Invitation testInvitation = new Invitation {
                Email = "testemail",
                InvitationStatus = InvitationStatus.Accepted,
                Id = invitationTestGuid,
                EventId = eventTestGuid
            };
            DateTime dateTime = DateTime.Now;
            Infrastructure.Entities.Event @event = new Infrastructure.Entities.Event("testeventname", "testeventdesc", dateTime); 
            
            {
                Description = "testevent",
                Name = "testeventname",
                Id = eventTestGuid,
                SentInvitations = new List<Invitation> { testInvitation }
            };

            _context.Add(@event);
            _context.SaveChanges();
        }

        private ReplyDTO setupDTO()
        {
            return new ReplyDTO(invitationTestGuid, true);
        }

        [Fact]
        public void ExecuteShould()
        {
            PopulateContext();
            var testUseCase = new ReplyUseCase(_context, participantFactory);
            ReplyDTO replyDTO = setupDTO();
            testUseCase.Execute(replyDTO);

            Event @event = _context.Find<Event>(eventTestGuid);

            Assert.NotEmpty(@event.Participants);
        }

    }
}

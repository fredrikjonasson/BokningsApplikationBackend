using Domain.Events;
using Domain.Invitations;
using Domain.Invitations.UseCases;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class SendInvitesTests
    {
        private readonly EventContext _context;
        private readonly IInvitationFactory _invitationFactory;
        private readonly IEventFactory _eventFactory;
        private readonly IEventRespository _eventRepository;

        public SendInvitesTests()
        {
            var options = new DbContextOptionsBuilder<EventContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _context = new EventContext(options);
            _invitationFactory = new Infrastructure.InvitationFactory();
            _eventFactory = new Infrastructure.EventFactory();
            _eventRepository = new EventRepository(_context);
        }

        [Fact]
        public void CanSendSingleInvite()
        {
            var @event = new PostEvent(_context, _eventFactory).Execute(new Event() { Name = "test", Description = "Test event", StartDate = DateTime.Now }); 
            var emails = new List<string>() { "asd@asd.com" };
            var input = new InvitationInput(emails, @event.Id);
            new SendInvitesUseCase(_context, _invitationFactory).Execute(input);
            var createdEvent = (Infrastructure.Entities.Event) new GetEvent(new EventRepository(_context)).Execute(@event.Id);
            Assert.NotEmpty(createdEvent.SentInvitations);
        }

        [Fact]
        public void CanSendMultipleInvites()
        {
            var @event = new PostEvent(_context, _eventFactory).Execute(new Event() { Name = "test", Description = "Test event", StartDate = DateTime.Now });
            var emails = new List<string>() { "asd@asd.com", "test@test.com" };
            var input = new InvitationInput(emails, @event.Id);
            new SendInvitesUseCase(_context, _invitationFactory).Execute(input);

            var createdEvent = (Infrastructure.Entities.Event) new GetEvent(new EventRepository(_context)).Execute(@event.Id);
            Assert.Equal(2, createdEvent.SentInvitations.Count);
        }
    }
}

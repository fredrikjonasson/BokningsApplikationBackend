using Domain.Invitations.UseCases;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class SendInvitesTests
    {
        private readonly EventContext _context;
        private readonly EntitiesFactory _factory;

        public SendInvitesTests()
        {
            var options = new DbContextOptionsBuilder<EventContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _context = new EventContext(options);
            _factory = new EntitiesFactory();
        }

        [Fact]
        public void CanSendSingleInvite()
        {
            var @event = _context.Add(new Infrastructure.Entities.Event("Fest", "Kul fest", DateTime.Now));
            var emails = new List<string>() { "asd@asd.com" };
            new SendInvitesUseCase(_context, _factory).Execute(emails, @event.Entity.Id);

            Assert.NotEmpty(_context.Find<Infrastructure.Entities.Event>(@event.Entity.Id).SentInvitations);
        }

        [Fact]
        public void CanSendMultipleInvites()
        {
            var @event = _context.Add(new Infrastructure.Entities.Event("Fest", "Kul fest", DateTime.Now));
            var emails = new List<string>() { "asd@asd.com", "test@test.com" };
            new SendInvitesUseCase(_context, _factory).Execute(emails, @event.Entity.Id);

            Assert.Equal(2, _context.Find<Infrastructure.Entities.Event>(@event.Entity.Id).SentInvitations.Count);
        }
    }
}

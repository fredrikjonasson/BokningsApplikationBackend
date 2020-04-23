using Domain;
using Domain.Events;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace UnitTests
{
    public class EventTests
    {
        private readonly EventContext _dbContext;

        public EventTests()
        {

            var options = new DbContextOptionsBuilder<EventContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            _dbContext = new EventContext(options);
        }

        [Fact]
        public void PostEventTest()
        {
            var myEvent = new Event()
            {
                Name = "Awesome Event",
                Description = "Partayy!",
                StartDate = DateTime.Now
            };
            var factory = new EntitiesFactory();
            var useCase = new PostEvent(_dbContext, factory);
            var @event = useCase.Execute(myEvent);

            Assert.NotEqual(@event.Id, Guid.Empty);
        }
    }
}

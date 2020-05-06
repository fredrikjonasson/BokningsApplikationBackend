using Domain.Users;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.EntityFrameworkCore;
using Domain.Events;
using WebApi.GetEventList;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class GetEventListControllerShould
    {
        private Mock<IUserService> _userServiceMock;
        private readonly EventContext _eventContext;

        public GetEventListControllerShould()
        {
            var options = new DbContextOptionsBuilder<EventContext>()
           .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
           .Options;

            _eventContext = new EventContext(options);
        }

        public void SetupTest()
        {
            _userServiceMock = new Mock<IUserService>();
            Guid guid = Guid.NewGuid();
            _userServiceMock.Setup(x => x.getUserId()).Returns(guid);

            _eventContext.Users.Add(new User
            {
                Id = guid
            });

            _eventContext.Organizers.Add(new Domain.Events.Organizer
            {
                Id = guid,

                Events = new List<Event>()
                {
                        new Event()
                        {
                            Name = "Berghain"
                        }
                }
            }); ;

            _eventContext.SaveChanges();
        }

        [Fact]
        public void TestingGetEventList()
        {
            SetupTest();

            var thaController = new GetEventListController(_userServiceMock.Object, _eventContext);

            var events = (OkObjectResult)thaController.GetEventList();

            Assert.NotEmpty((IEnumerable<Event>)events.Value);

        }
    }
}

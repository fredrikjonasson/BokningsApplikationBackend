using Domain.Users;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    [TestClass]
    public class GetEventListControllerShould
    {
        private readonly IUserService _userServiceMock;
        private readonly EventContext _eventContext;

        public GetEventListControllerShould()
        {
        }

        public void SetupTest() { 
            var _userServiceMock = new Mock<IUserService>();
            Guid guid = new Guid();
            _userServiceMock.Setup(x => x.getUserId()).Returns(guid);
            _eventContext = new EventContext { 
            Users = new DbSet<User> {
                
            
            }
            }
        }
    }
}

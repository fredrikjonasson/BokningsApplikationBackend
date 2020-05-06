using Domain.Events;
using Domain.Events.Interfaces;
using Domain.Users;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WebApi.GetEventList
{
    [ApiController]
    [Route("events")]
    public class GetEventListController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly EventContext _eventContext;


        public GetEventListController(IUserService userService, EventContext eventContext)
        {
            _userService = userService;
            _eventContext = eventContext;
        }

        [HttpGet]
        public ActionResult GetEventList()
        {
            Guid id = _userService.getUserId();
            var user = _eventContext.Users.Find(id);
            var organizer = _eventContext.Organizers.First(x => id == user.Id);
            return Ok(organizer.Events);
        }
    }
}

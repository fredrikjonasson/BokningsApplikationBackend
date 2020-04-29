using Domain.Events;
using Domain.Events.Interfaces;
using Domain.User;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.GetEventList
{
    [ApiController]
    [Route("events")]
    public class GetEventListController : ControllerBase
    {
        private readonly IGetEvent _getEvent;
        private readonly IUserService _userService;
        private readonly EventContext _eventContext;


        public GetEventListController(IGetEvent getEvent, IUserService userService, EventContext eventContext)
        {
            _getEvent = getEvent;
            _userService = userService;
            _eventContext = eventContext;
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<Event> GetEventList()
        {
            string id = _userService.getUserId();
            _DbContext.Set<Event>().Where(x => x.);
            _eventContext.Events.Where
            throw new NotImplementedException();
        }
    }


}

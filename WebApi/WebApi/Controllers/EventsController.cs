using Domain;
using Domain.Events;
using Domain.Events.Extensions;
using Domain.Events.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IPostEvent _postEvent;
        private readonly IGetEvent _getEvent;

        public EventsController(IPostEvent postEvent, IGetEvent getEvent)
        {
            _postEvent = postEvent;
            _getEvent = getEvent;
        }

        [HttpPost]
        public ActionResult Post(EventDto myEvent)
        {
            var @convertedEvent = myEvent.ConvertToDomain();
            var @event = _postEvent.Execute(convertedEvent);
            return CreatedAtAction(nameof(GetById), new { id = @event.Id }, @event);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(Guid id)
        {
            var @event = _getEvent.Execute(id);
            return Ok(@event);
        }
    }
}

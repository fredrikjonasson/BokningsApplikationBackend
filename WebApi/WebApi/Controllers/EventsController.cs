using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public ActionResult Post(Event myEvent)
        {
            var @event = _postEvent.Execute(myEvent);
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

using Domain;
using Domain.Events;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        public IPostEvent postEvent { get; set; }
        public IGetEvent getEvent { get; set; }

        public EventsController(IPostEvent postEvent, IGetEvent getEvent)
        {
            this.postEvent = postEvent;
            this.getEvent = getEvent;
        }

        [HttpPost]
        public ActionResult Post(Event myEvent)
        {
            var @event = postEvent.Execute(myEvent);
            return CreatedAtAction(nameof(GetById), @event.Id, @event);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(Guid id)
        {
            var @event = getEvent.Execute(id);
            return Ok(@event);
        }
    }
}

using Domain.Events;
using Domain.Events.Extensions;
using Domain.Events.Interfaces;
using Domain.Interfaces;
using Domain.Invitations.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.CreateEvent
{
    [ApiController]
    [Route("events")]
    public class PostEventsController : ControllerBase
    {
        private readonly IPostEvent _postEvent;
        private readonly IGetEvent _getEvent;
        private readonly IUseCase<InvitationInput> _inviteUseCase;
        private readonly IEventFactory _eventFactory;

        public PostEventsController(IPostEvent postEvent, IGetEvent getEvent, IUseCase<InvitationInput> inviteUseCase)
        {
            _postEvent = postEvent;
            _getEvent = getEvent;
            _inviteUseCase = inviteUseCase;
            _eventFactory = new Domain.Events.EventFactory();
        }

        [HttpPost]
        public ActionResult Post(EventDto myEvent)
        {
            var @convertedEvent = myEvent.ConvertToDomain(_eventFactory);
            var @event = _postEvent.Execute(convertedEvent);
            _inviteUseCase.Execute(new InvitationInput(myEvent.SentInvitations, @event.Id));
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

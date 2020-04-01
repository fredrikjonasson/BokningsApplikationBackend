using Domain;
using Domain.Events;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        public IPostEvent eventDto { get; set; }

        public EventsController(IPostEvent eventDto)
        {
            this.eventDto = eventDto;
        }

        [HttpPost]
        public ActionResult Post(IPostEvent eventDto)
        {
            var cratedEvent = eventDto.Execute();
            return Ok(cratedEvent);
        }
    }
}

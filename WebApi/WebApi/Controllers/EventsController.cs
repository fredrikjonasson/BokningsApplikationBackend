using Domain;
using Domain.Events;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        public EventsController()
        {

        }

        [HttpPost]
        public ActionResult Post(Event eventDto)
        {
            var command = new PostEvent();
            var cratedEvent = command.Execute();
            return Ok(cratedEvent):

        }
    }
}

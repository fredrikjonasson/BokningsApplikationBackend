using Domain.Events.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Events
{
    public class PostEvent : IPostEvent
    {
        private readonly DbContext dbContext;
        private readonly IEventFactory _eventFactory;

        public PostEvent(DbContext dbContext, IEventFactory eventFactory)
        {
            this.dbContext = dbContext;
            _eventFactory = eventFactory;
        }

        public IEvent Execute(Event @event)
        {
            //Göra Repository pattern???
            var myEvent = dbContext.Add(_eventFactory.CreateEvent(@event.Name, @event.Description, @event.StartDate));
            dbContext.SaveChanges();

            return myEvent.Entity;
        }
    }
}

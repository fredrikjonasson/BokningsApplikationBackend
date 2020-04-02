using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Events
{
    public class PostEvent : IPostEvent
    {
        private readonly DbContext dbContext;

        public PostEvent(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Event Execute(Event @event)
        {
            dbContext.Add<Event>(@event);
            dbContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}

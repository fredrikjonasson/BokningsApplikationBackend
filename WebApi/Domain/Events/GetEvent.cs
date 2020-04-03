using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class GetEvent : IGetEvent
    {
        private readonly DbContext _dbContext;

        public GetEvent(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Event Execute(Guid id)
        {
            return _dbContext.Find<Event>(id);
        }
    }
}

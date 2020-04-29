using Domain.Events;
using Domain.Invitations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRespository
    {
        private readonly DbContext _context;

        public EventRepository(DbContext context)
        {
            _context = context;
        }

        public IEvent GetById(Guid id)
        {   
            return _context.Set<Entities.Event>().Include(e => e.SentInvitations).Single(e => e.Id == id);
        }
    }
}

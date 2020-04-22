using Domain;
using Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }
        public DbSet<Entities.Event> Events { get; set; }

        public DbSet<Organizer> Organizers { get; set; }
    }
}

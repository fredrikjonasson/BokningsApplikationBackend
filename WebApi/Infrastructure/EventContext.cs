using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EventContext : DbContext
    {
        DbSet<Event> Events { get; set; }

        DbSet<Organizer> Organizers { get; set; }
    }
}

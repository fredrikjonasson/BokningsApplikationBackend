using Domain.Users;
using Domain.Events;
using Microsoft.EntityFrameworkCore;
using Domain.Participants;

namespace Infrastructure
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }
        public DbSet<Entities.Event> Events { get; set; }
        public DbSet<Entities.Invitation> Invitations { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entities.Participant>();
            //modelBuilder.Entity<Entities.Participant>().HasBaseType<Participant>();
            base.OnModelCreating(modelBuilder);
        }
    }
}

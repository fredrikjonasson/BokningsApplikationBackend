using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Organizer
    {
        public Guid Id { get; set; }

        public string Name { get; set;}

        public ICollection<Event> Event { get; set; }

    }
}

using Domain.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Events
{
    public class EventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public List<string> SentInvitations { get; set; }
    }
}

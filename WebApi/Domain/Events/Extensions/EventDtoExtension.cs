using Domain.Events.Interfaces;
using Domain.Invitations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domain.Events.Extensions
{
    public static  class EventDtoExtension
    {
        public static Event ConvertToDomain(this EventDto dto)
        {
            var @event = new Event
            {
                StartDate = dto.StartDate,
                Description = dto.Description,
                Name = dto.Name,
                SentInvitations = dto.SentInvitations.Select(x => new Invitation { Email = x }).ToList()
            };

            return @event;
        }
    }
}

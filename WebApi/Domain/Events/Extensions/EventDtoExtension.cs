using Domain.Events.Interfaces;
using Domain.Invitations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domain.Events.Extensions
{
    public static class EventDtoExtension
    {
        public static IEvent ConvertToDomain(this EventDto dto, IEventFactory eventFactory)

        {
            var @event = eventFactory.CreateEvent(dto.Name, dto.Description, dto.StartDate);

            return @event;
        }
    }
}

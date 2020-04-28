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
        //public static Event ConvertToDomain(this EventDto dto, IEventFactory eventFactory)
        public static IEvent ConvertToDomain(this EventDto dto, IEventFactory eventFactory)

        {
            var @event = eventFactory.CreateEvent(dto.Name, dto.Description, dto.StartDate);
            //{
            //    StartDate = dto.StartDate,
            //    Description = dto.Description,
            //    Name = dto.Name,
            //    SentInvitations = dto.SentInvitations.Select(x => new Invitation { Email = x }).ToList<IInvitation>()
            //};

            return @event;
        }
    }
}

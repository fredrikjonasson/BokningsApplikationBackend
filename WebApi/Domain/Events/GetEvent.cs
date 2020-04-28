using Domain.Events.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Events
{
    public class GetEvent : IGetEvent
    {
        private readonly IEventRespository _eventRepository;

        public GetEvent(IEventRespository repository)
        {
            _eventRepository = repository;
        }

        public IEvent Execute(Guid id)
        {
            return _eventRepository.GetById(id);
        }
    }
}

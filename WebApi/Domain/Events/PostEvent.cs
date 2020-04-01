using Domain.Interfaces;
using System;

namespace Domain.Events
{
    public class PostEvent : IPostEvent
    {
        public Event Execute()
        {
            throw new NotImplementedException();
        }
    }
}

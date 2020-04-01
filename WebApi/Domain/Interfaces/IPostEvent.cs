using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IPostEvent
    {
        public Event Execute();
    }
}

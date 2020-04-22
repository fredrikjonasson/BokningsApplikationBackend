using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Interfaces
{
    public interface IInvitation
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Answered { get; set; }
    }
}

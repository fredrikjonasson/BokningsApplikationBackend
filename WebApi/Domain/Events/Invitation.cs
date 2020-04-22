using System;
using Domain.Events.Interfaces;

namespace Domain.Events
{
    public class Invitation : IInvitation
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Answered { get; set; } = false;
    }
}

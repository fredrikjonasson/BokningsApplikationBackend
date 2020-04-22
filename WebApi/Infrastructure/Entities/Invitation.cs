
using Domain.Events.Interfaces;
using System;

namespace Infrastructure.Entities
{
    public class Invitation : IInvitation
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Answered { get; set; }
    }
}

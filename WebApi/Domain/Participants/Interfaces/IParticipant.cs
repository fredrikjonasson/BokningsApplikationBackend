using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Participants.Interfaces
{
    public interface IParticipant
    {
        public Guid Id { get; set; }
        public IContactInformation ContactInformation { get; set; }
    }
}

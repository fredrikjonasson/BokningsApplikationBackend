using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Domain.Participants.Interfaces
{
    public interface IParticipantFactory
    {
        public Participant CreateParticipant(string firstName, string lastName, string email);
    }
}

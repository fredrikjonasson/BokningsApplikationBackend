using Domain.Participants;
using Domain.Participants.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ParticipantFactory : IParticipantFactory
    {
        public Participant CreateParticipant(string firstName, string lastName, string email)
        {
            ContactInformation contactInformation = new ContactInformation
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            Participant participant = new Participant { ContactInformation = contactInformation };
            return participant;
        }
    }
}

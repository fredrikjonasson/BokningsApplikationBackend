using Domain.Participants.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Participants
{
    public class ContactInformation: IContactInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

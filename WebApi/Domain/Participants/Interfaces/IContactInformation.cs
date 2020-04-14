using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Participants.Interfaces
{
    public interface IContactInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

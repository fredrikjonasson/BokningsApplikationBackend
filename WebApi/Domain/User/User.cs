using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
    }
}

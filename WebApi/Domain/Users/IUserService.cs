using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users
{
    public interface IUserService
    {
        public string getExternalId();
        public Guid getUserId();
    }
}

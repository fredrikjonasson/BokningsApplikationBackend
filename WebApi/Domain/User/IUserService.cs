using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public interface IUserService
    {
        public string getExternalId();
        public string getUserId();
    }
}

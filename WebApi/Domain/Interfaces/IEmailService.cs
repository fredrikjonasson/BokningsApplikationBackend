using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IEmailService
    {
        public List<string> SendEmail(string from, List<string> to, string message);

    }
}

using Domain.Events;
using Domain.Participants;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Domain.Interfaces
{
    public interface IEmailService
    {
        public List<Participant> SendEmail(string from, List<string> to, string message);

    }
}

using Domain.Events;
using Domain.Interfaces;
using Domain.Participants;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Domain.Invitations.UseCases.SendInvites
{
    public class EmailService : IEmailService
    {
        public List<Participant> SendEmail(string from, List<string> recipiants, string message)
        {
            var newMessage = new MimeMessage();
            var bodyBuilder = new BodyBuilder();

            // from
            newMessage.From.Add(new MailboxAddress(from, from));
            // to
            recipiants.ForEach(x => newMessage.To.Add(new MailboxAddress(x, x)));

            // newMessage to
            newMessage.ReplyTo.Add(new MailboxAddress("reply_name", "reply_email@example.com"));

            newMessage.Subject = "subject";
            bodyBuilder.HtmlBody = message;
            newMessage.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();

            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
            client.Authenticate("", "");
            client.Send(newMessage);
            client.Disconnect(true);

            return null;

        }
    }
}

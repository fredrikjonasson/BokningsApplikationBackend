using Domain.Interfaces;
using Domain.Participants;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Invitations.UseCases.SendInvites
{
    public class EmailService : IEmailService
    {
        public List<Participant> SendEmail()
        {
            var message = new MimeMessage();
            var bodyBuilder = new BodyBuilder();

            // from
            message.From.Add(new MailboxAddress("from_name", "from_email@example.com"));
            // to
            message.To.Add(new MailboxAddress("to_name", "to_email@example.com"));
            // reply to
            message.ReplyTo.Add(new MailboxAddress("reply_name", "reply_email@example.com"));

            message.Subject = "subject";
            bodyBuilder.HtmlBody = "Hej, du har blivit inbjuden till fest, klicka på länken och svara";
            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();

            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //client.Connect("MAIL_SERVER", 465, SecureSocketOptions.SslOnConnect);
            //client.Authenticate("USERNAME", "PASSWORD");
            client.Send(message);
            client.Disconnect(true);

            return null;

        }
    }
}

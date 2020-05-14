using Domain.Configuration;
using Domain.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Collections.Generic;

namespace Infrastructure
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public List<string> SendEmail(string from, List<string> recipiants, string message)
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
            client.Connect(_settings.SmtpAddress, 465, SecureSocketOptions.SslOnConnect);
            client.Authenticate(_settings.Username, _settings.Password);
            client.Send(newMessage);
            client.Disconnect(true);

            return recipiants;

        }
    }
}

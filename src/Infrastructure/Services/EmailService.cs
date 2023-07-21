using Excallibur.Application.Common.Interfaces;
using Excallibur.Domain.Entites;
using MailKit.Net.Smtp;
using MimeKit;

namespace Excallibur.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly Email _email;
        public EmailService(Email email)
        {
            _email = email ?? throw new ArgumentNullException(nameof(email));
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _email.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_email.SmtpServer, _email.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_email.UserName, _email.Password);

                client.Send(mailMessage);

            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}

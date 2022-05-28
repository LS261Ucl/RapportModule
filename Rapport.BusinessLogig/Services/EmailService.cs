using Rapport.Entites;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;
using Rapport.BusinessLogig.Interfaces;

namespace Rapport.BusinessLogig.Services
{
    public class EmailService : IMailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("	maribel.mcdermott84@ethereal.email "));
            email.To.Add(MailboxAddress.Parse("	maribel.mcdermott84@ethereal.email "));
            email.Subject = "Test email";
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("	maribel.mcdermott84@ethereal.email ").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

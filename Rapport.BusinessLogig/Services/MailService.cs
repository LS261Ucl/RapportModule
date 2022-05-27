using Microsoft.Extensions.Configuration;
using Rapport.BusinessLogig.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Rapport.BusinessLogig.Services
{
    public class MailService : IMailService
    {
        
            private IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@authdemo.com", "JWT Auth Demo");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
    
}

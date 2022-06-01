using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rapport.Entites;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Extensions
{
    public class MailExtension
    {

        private readonly ISendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;


        public MailExtension(ISendGridClient sendGridClient,
            IConfiguration configuration)
        {
            _sendGridClient = sendGridClient;
            _configuration = configuration;
        }

   
        public async Task SendPlaintextEmail(string toEmail)
        {
            string fromEmail = _configuration.GetSection("SendGrindEmailSettings")
                .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGrindEmailSettings")
                .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = "Plain Text Email",
                PlainTextContent = "Hello World"
            };

            msg.AddTo(toEmail);

            var response = await _sendGridClient.SendEmailAsync(msg);

            string message = response.IsSuccessStatusCode ? "Email Send" : "Email Sending Failed";
             
        }

        
    
        public async Task SendEmailFileAttchement([FromForm] EmilFileAttachment emailFile)
        {
            string fromEmail = _configuration.GetSection("SendGrindEmailSettings")
            .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGrindEmailSettings")
            .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = "File Attachement Email",
                PlainTextContent = "Check Attached File",

            };

            await msg.AddAttachmentAsync(
                emailFile.DataFile.FileName,
                emailFile.DataFile.OpenReadStream(),
                emailFile.DataFile.ContentType,
                "attachment"
            );
            msg.AddTo(emailFile.ToEmail);

            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Send Successfully" :
            "Email Sending Failed";
          
        }
    }
}

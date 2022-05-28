using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly ISendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;


        public EmailController(ISendGridClient sendGridClient,
            IConfiguration configuration)
        {
            _sendGridClient = sendGridClient;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("send-text-mail")]
        public async Task<IActionResult> SendPlaintextEmail(string toEmail)
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
            return Ok(message);
        }

        [HttpPost]
        [Route("send-mail-with-file-attachement")]
        public async Task<IActionResult> SendEmailFileAttchement([FromForm] EmilFileAttachment emailFile)
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
            return Ok(message);
        }

        //[HttpPost]
        //[Route("send-html-mail")]
        //public async Task<IActionResult> SendHtmlEmail(FinalReport finalReport)
        //{
        //    string fromEmail = _configuration.GetSection("SendGrindEmailSettings")
        //    .GetValue<string>("FromEmail");

        //    string fromName = _configuration.GetSection("SendGrindEmailSettings")
        //    .GetValue<string>("FromName");

        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress(fromEmail, fromName),
        //        Subject = "HTML Email",
        //        HtmlContent = EmailHTMLTemplate(heroEmail)
        //    };
        //    msg.AddTo(heroEmail.ToEmail);
        //    var response = await _sendGridClient.SendEmailAsync(msg);
        //    string message = response.IsSuccessStatusCode ? "Email Send Successfully" :
        //    "Email Sending Failed";
        //    return Ok(message);
        //}
    }
}

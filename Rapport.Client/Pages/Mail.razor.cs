using Microsoft.AspNetCore.Components;
using Rapport.Shared.Dto_er;

namespace Rapport.Client.Pages
{
    public partial class Mail : ComponentBase
    {
        private EmailDto? EmailDto { get; set; } = new();
        private string? message { get; set; }
        private bool? isSend { get; set; } = false;


        [Inject]
        private IMailService _mailService { get; set; }

        private async Task SendMail(string toMail, string subject, string body)
        {
            
            var mail = new EmailDto
            {
                To = toMail,
                Subject = subject,
                Body = body
            };

            var result = await _mailService.SendEmail(mail);

            if( result != null)
            {
                isSend = true;
                message = "beskeden er sendt";
            }
            else
            {
                message = "Der er sket en fejl, prøv igen";
            }

        }





    }
}

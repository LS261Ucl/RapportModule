using Rapport.Entites;
using Rapport.Shared.Dto_er;

namespace Rapport.Client.Interfaces
{
    public interface IMailService
    {
        Task<EmailDto> SendEmail(EmailDto emailDto);
        Task SendEmailWhitFileAsync(EmilFileAttachment emilFile);
        
    }
}

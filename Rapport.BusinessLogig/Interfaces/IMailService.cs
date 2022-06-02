using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IMailService
    {
        Task<IActionResult> SendPlainTextEmail(EmailDto emailDto);

        Task<IActionResult> SendEmailFileAttachment([FromForm] EmilFileAttachment emailFile);

    }
}

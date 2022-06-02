using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class MailService : IMailService
    {
        public Task<IActionResult> SendEmailFileAttachment([FromForm] EmilFileAttachment emailFile)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> SendPlainTextEmail(EmailDto emailDto)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class ReportElementService : IReportElementService
    {
        public Task<ReportElement> CreateReportElement([FromBody] CreateReportElementDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReportElementDto> GetReportElementById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Shared.Dto_er.FinalReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class FinalReportService : IFinalReportService
    {
        public Task<FinalReportDto> CreateReportElement([FromBody] CreateFinalReportDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FinalReportDto> GetFinalReportById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

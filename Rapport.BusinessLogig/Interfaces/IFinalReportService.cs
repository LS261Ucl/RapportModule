using Microsoft.AspNetCore.Mvc;
using Rapport.Shared.Dto_er.FinalReport;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IFinalReportService
    {
        Task<FinalReportDto> GetFinalReportById(int id);
        Task<FinalReportDto> CreateReportElement([FromBody] CreateFinalReportDto requestDto);
        Task DeleteReportElement(int id);
    }
}

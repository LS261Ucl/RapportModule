using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IReportElementService
    {
        Task<ActionResult<List<ReportElementDto>>> GetReportElements();
        Task<ActionResult<ReportElementDto>> GetReportElementById(int id);
        Task<ActionResult<ReportElement>> CreateReportElement([FromBody] CreateReportElementDto requestDto);
        Task<ActionResult<ReportElement>> UpdateReportElement(int id, UpdateReportElementDto requestDto);
        Task<ActionResult> DeleteReportElement(int id);
    }
}

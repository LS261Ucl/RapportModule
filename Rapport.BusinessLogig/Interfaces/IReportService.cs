using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Report;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IReportService
    {
        Task<ActionResult<List<ReportDto>>> GetReports();
        Task<ActionResult<ReportDto>> GetReportById(int id);
        Task<ActionResult<ReportDto>> GetReportwhitchildren(int id);
        Task<ActionResult<Report>> CreateReport([FromBody] CreateReportDto requestDto);
        Task<ActionResult<Report>> UpdateReport(int id, UpdateReportDto requestDto);
        Task<ActionResult> DeleteReport(int id);
    }
}

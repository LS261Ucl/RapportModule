using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Report;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetReports();
        Task<ReportDto> GetReportyId(int id);
        Task<ReportDto> GetReportAndItsChilderen(int id);
        Task<Report> CreateReport([FromBody] CreateReportDto requestDto);
        //  Task<Template> UpdateTemplate(int id, TemplateDto requestDto);
        Task DeleteReport(int id);
    }
}

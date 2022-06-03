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
        Task<ReportDto> CreateReport([FromBody] CreateReportDto requestDto);
        Task<Report> UpdateReport(int id, ReportDto requestDto);
        Task DeleteReport(int id);
       
    }
}

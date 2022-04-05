using Rapport.Shared.Dto_er.Customer;
using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.Client.Interfaces
{
    public interface IReportService
    {
        event Action OnChange;
        List<ReportDto> ReportDtos { get; set; }
        List<ReportGroupDto> GroupDtos { get; set; }
        List<CustomerDto> CustomerDtos { get; set; }
        Task<ReportDto> GetReportById(int id);
        Task<ReportDto> GetReportGroupByReportId(int id);

        Task<List<ReportDto>> GetReports();
        Task<ReportDto> CreateReport(int id, string templateTitel, string templateDecription, CreateReportDto requestDto);

        Task<ReportDto> UpdatedReport(int id, UpdateReportDto requestDto);
        Task<bool> DeletedReport(int id);

        Task<ReportDto> GetReportWhitGroupsAndFields(int id);
    }
}

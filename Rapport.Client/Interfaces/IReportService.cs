using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.Client.Interfaces
{
    public interface IReportService
    {
        event Action OnChange;
        List<ReportDto> ReportDtos { get; set; }
        List<ReportGroupDto> GroupDtos { get; set; }
        Task<ReportDto> GetReportById(int id);
        Task<ReportDto> GetReportGroupByReportId(int id);
        Task<List<ReportDto>> GetReports();
        Task<ReportDto> CreateReport(int id, string templateTitel, int? layoutId, CreateReportDto requestDto);
        Task<ReportDto> UpdatedReport(int id, ReportDto requestDto);
        Task<bool> DeletedReport(int id);
        Task<ReportDto> GetReportWhitGroupsAndFields(int id);
        //Task<ReportDto> SearchReports(string searchText);
    }
}

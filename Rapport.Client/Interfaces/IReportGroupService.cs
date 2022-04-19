using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.Client.Interfaces
{
    public interface IReportGroupService
    {
        event Action OnChange;
        Task<ReportGroupDto> CreateReport(int id, CreateReportGroupDto requestDto);

        Task<ReportGroupDto> GetReportGroupById(int id);

    }
}

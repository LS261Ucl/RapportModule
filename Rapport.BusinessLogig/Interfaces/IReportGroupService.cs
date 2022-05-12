using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IReportGroupService
    {
        Task<List<ReportGroupDto>> GetReportGroups();
        Task<ReportGroupDto> GetReportGroupById(int id);
        Task<ReportGroup> CreateReportGroup([FromBody] CreateReportGroupDto requestDto);
        Task<ReportGroup> UpdateReportGroup(int id, ReportGroupDto requestDto);
        Task DeleteReportGroup(int id);
    }
}

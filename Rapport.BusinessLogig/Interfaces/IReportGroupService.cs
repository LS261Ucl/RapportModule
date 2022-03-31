using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IReportGroupService
    {
        Task<ActionResult<List<ReportGroupDto>>> GetReportGroups();
        Task<ActionResult<ReportGroupDto>> GetReportGroupById(int id);
        Task<ActionResult<ReportGroup>> CreateReportGroup([FromBody] CreateReportGroupDto requestDto);
        Task<ActionResult<ReportGroup>> UpdateReportGroup(int id, UpdateReportGroupDto requestDto);
        Task<ActionResult> DeleteReportGroup(int id);
    }
}

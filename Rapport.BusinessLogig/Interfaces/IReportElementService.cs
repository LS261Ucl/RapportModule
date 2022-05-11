using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IReportElementService
    {
        Task<ReportElementDto> GetReportElementById(int id);
        Task<ReportElement> CreateReportElement([FromBody] CreateReportElementDto requestDto);
        //  Task<Template> UpdateTemplate(int id, TemplateDto requestDto);
        Task DeleteReportElement(int id);
    }
}

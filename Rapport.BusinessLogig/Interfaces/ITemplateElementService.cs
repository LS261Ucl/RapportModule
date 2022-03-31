using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateElement;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface ITemplateElementService
    {
        Task<ActionResult<List<TemplateElementDto>>> GetTemplateElements();
        Task<ActionResult<TemplateElementDto>> GetTemplateElementById(int id);
        Task<ActionResult<TemplateElement>> CreateTemplateElement([FromBody]CreateTemplateElementDto requestDto);
        Task<ActionResult<TemplateElement>> UpdateTemplateElement(int id, UpdateTemplateElementDto requestDto);
        Task<ActionResult> DeleteTemplateElement(int id);
    }
}

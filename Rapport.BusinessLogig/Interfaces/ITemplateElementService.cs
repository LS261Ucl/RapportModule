using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateElement;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface ITemplateElementService
    {
        Task<ActionResult<List<TemplateElementDto>>> GetAllTemplateElements();
        Task<ActionResult<TemplateElementDto>> GetTemplateElementById(int id);
        Task<ActionResult<TemplateElement>> CreateTemplateElement([FromBody]CreateTemplateElementDto requestDto);
        Task<ActionResult> UpdateTemplateElement(int id, TemplateElementDto requestDto);
        Task<ActionResult> DeleteTemplateElement(int id);
    }
}

using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateElement;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface ITemplateElementService
    {
        Task<List<TemplateElementDto>> GetTemplateElemens();
        Task<TemplateElementDto> GetTemplateElementById(int id);
        Task<TemplateElement> CreateTemplateElement([FromBody] CreateTemplateElementDto requestDto);
        Task<TemplateElement> UpdateTemplate(int id, TemplateElementDto requestDto);
        Task DeleteTemplateElement(int id);
    }
}

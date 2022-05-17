using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface ITemplateService
    {

        Task<List<TemplateDto>> GetTemplates();
        Task<TemplateDto> GetTemplateById(int id);
        Task<TemplateDto> GetTemplateAndItsChilderen(int id);
        Task<Template> CreateTemplate([FromBody] CreateTemplateDto requestDto);
        Task<Template> UpdateTemplate(int id, TemplateDto requestDto);
        Task DeleteTemplate(int id);


    }
}

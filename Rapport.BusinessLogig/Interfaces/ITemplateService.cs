using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface ITemplateService
    {
        Task<ActionResult<List<TemplateDto>>> GetAllTemplate();
        //Task<ActionResult<List<TemplateDto>>> GetTemplate(int id);
        Task<ActionResult<TemplateDto>> GetTemplateWhitChilderen(int id);
        Task<ActionResult<Template>> CreateTemplate(CreateTemplateDto requestDto);
        Task<ActionResult<Template>> UpdateTemplate(int id, TemplateDto requestDto);


    }
}

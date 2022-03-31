using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateGroup;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface ITemplateGroupService
    {
        Task<ActionResult<List<TemplateGroupDto>>> GetAllTemplateGroups();
        Task<ActionResult<TemplateGroupDto>> GetTemplateGroupById(int id);
        Task<ActionResult<TemplateGroupDto>> GetTemplateGroupWhitChild(int id);
        Task<ActionResult<TemplateGroup>> CreateTemplateGroup([FromBody] CreateTemplateGroupDto requestDto);
        Task<ActionResult> UpdateTemplateGroup(int id, TemplateGroupDto requestDto);
        Task<ActionResult> DeleteTemplateGroup(int id);
    }
}

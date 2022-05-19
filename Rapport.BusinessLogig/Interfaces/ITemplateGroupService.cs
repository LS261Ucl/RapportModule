using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateGroup;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface ITemplateGroupService
    {
        Task<List<TemplateGroupDto>> GetTemplategroups();
        Task<TemplateGroupDto> GetTemplateGroupById(int id);
        Task<TemplateGroup> CreateTemplateGroup([FromBody] CreateTemplateGroupDto requestDto);
        Task<TemplateGroup> UpdateTemplate(int id, TemplateGroupDto requestDto);
        Task DeleteTemplateGroup(int id);
    }
}

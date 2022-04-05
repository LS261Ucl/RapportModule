using Rapport.Shared.Dto_er.TemplateGroup;

namespace Rapport.Client.Interfaces
{
    public interface ITemplateGroupService
    {
        event Action OnChange;
        Task<TemplateGroupDto> GetTemplateGroupById(int id);
        Task<TemplateGroupDto> CreateTemplateGroup(int id, CreateTemplateGroupDto requestDto);
        Task<TemplateGroupDto> UpdatedTemplateGroup(int id, TemplateGroupDto groupDto);
        Task<bool> DeletedTemplateGroup(int id);
        Task<TemplateGroupDto> GetFieldsWhitGroupId(int id);
        Task<List<TemplateGroupDto>> GetAllGroups();
    }
}

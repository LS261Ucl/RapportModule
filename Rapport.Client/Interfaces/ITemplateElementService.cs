using Rapport.Shared.Dto_er.TemplateElement;

namespace Rapport.Client.Interfaces
{
    public interface ITemplateElementService
    {
        event Action OnChange;
        Task<TemplateElementDto> GetTemplateElementById(int id);
        Task<List<TemplateElementDto>> GetTemplateElementByGroupId(int groupId);
        Task<TemplateElementDto> CreateTemplateElement(int id, CreateTemplateElementDto requestDto);
        Task<TemplateElementDto> UpdatedTemplateElement(int id, TemplateElementDto elementDto);
        Task<bool> DeletedTemplateElement(int id);
    }
}

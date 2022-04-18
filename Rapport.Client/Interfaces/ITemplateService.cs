using Rapport.Shared.Dto_er.Template;

namespace Rapport.Client.Interfaces
{
    public interface ITemplateService
    {
        event Action OnChange;
        List<TemplateDto> TemplateDtos { get; set; }
        //List<TemplateGroupDto> GroupDtos { get; set; }
        Task<TemplateDto> GetTemplateById(int id);
        Task<TemplateDto> GetTemplateGroupByTemplateId(int id);

        Task<List<TemplateDto>> GetTemplates();
        Task<TemplateDto> CreateTemplate();

        Task<TemplateDto> UpdatedTemplate(int id, TemplateDto updateDto);
        Task<bool> DeletedTemplate(int id);
    }
}

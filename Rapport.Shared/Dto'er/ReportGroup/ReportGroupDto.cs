using Rapport.Shared.Dto_er.ReportElement;
using Rapport.Shared.Dto_er.TemplateGroup;

namespace Rapport.Shared.Dto_er.ReportGroup
{
    public class ReportGroupDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }

        public int TemplateGroupId { get; set; }
        public TemplateGroupDto? TemplateGroup { get; set; }
        public ICollection<ReportElementDto>? Elements { get; set; }
    }
}

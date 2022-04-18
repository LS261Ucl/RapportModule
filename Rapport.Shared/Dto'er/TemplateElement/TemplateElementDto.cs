using Rapport.Shared.Dto_er.ReportElement;
using Rapport.Shared.Dto_er.TemplateGroup;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.TemplateElement
{
    public class TemplateElementDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int Datatype { get; set; }
        public string? Options { get; set; }

        public int TemplateGroupId { get; set; }

        [JsonIgnore]
        public TemplateGroupDto? TemplateGroup { get; set; }
        public ICollection<ReportElementDto>? ReportElements { get; set; }
    }
}

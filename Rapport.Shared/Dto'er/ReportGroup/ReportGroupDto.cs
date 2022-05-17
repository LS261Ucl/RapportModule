using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.ReportElement;
using Rapport.Shared.Dto_er.TemplateGroup;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.ReportGroup
{
    public class ReportGroupDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }

        public int? ReportId { get; set; }

        [JsonIgnore]
        public ReportDto? ReportDto { get; set; }

        public int TemplateGroupId { get; set; }

        [JsonIgnore]
        public TemplateGroupDto? TemplateGroup { get; set; }
        public ICollection<ReportElementDto>? Elements { get; set; }
    }
}

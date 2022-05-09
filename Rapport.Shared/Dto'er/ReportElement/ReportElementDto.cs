using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.TemplateElement;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.ReportElement
{
    public class ReportElementDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int DataType { get; set; }
        public string? Options { get; set; }
        public string? Remarks { get; set; }
        public double Numbers { get; set; }
        public bool? IsActive { get; set; }
        
        public int ReportGroupId { get; set; }
        [JsonIgnore]
        public ReportGroupDto? ReportGroup { get; set; }       
        public int TemplateElementId { get; set; }

        [JsonIgnore]
        public TemplateElementDto? TemplateElement { get; set; }
    }
}

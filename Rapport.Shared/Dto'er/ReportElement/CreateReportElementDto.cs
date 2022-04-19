using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.TemplateElement;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.ReportElement
{
    public class CreateReportElementDto
    {

        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int DataType { get; set; }
        public string? Options { get; set; }
        public string? Remarks { get; set; }
        public double Numbers { get; set; }
        public byte[]? Image { get; set; }
        public bool IsActive { get; set; }
      
        [Required]
        public int ReportGroupId { get; set; }

        [JsonIgnore]
        public ReportGroupDto? ReportGroupDto { get; set; }

        [Required]
        public int TemplateElementId { get; set; }

        [JsonIgnore]
        public TemplateElementDto? TemplateElementDto { get; set; }

    }
}

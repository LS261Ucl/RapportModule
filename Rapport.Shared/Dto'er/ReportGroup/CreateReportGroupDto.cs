using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.TemplateGroup;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.ReportGroup
{
    public class CreateReportGroupDto
    {
        [Required]
        public string? Titel { get; set; }

        [Required]
        public int ReportId { get; set; }

        //[JsonIgnore]
        //public ReportDto? ReportDto { get; set; }

        [Required]
        public int TemplateGroupId { get; set; }

        //[JsonIgnore]
        //public TemplateGroupDto? TemplateGroupDto { get; set; }


    }
}

using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.Template;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.Report
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? Date { get; set; }

        public int LayoutId { get; set; }

        public string? Remarks { get; set; }

        public bool? IsReadOnly { get; set; }
  
        public int TemplateId { get; set; }

        public string? CustomerEmail { get; set; }

        public string? EmployeeName { get; set; }

        [JsonIgnore]
        public TemplateDto? Template { get; set; }
   
        public ICollection<ReportGroupDto>? ReportGroups { get; set; }
    }
}

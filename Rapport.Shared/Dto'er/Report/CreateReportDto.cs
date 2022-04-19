using Rapport.Shared.Dto_er.Template;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.Report
{
    public class CreateReportDto
    {
        public string? Title { get; set; }
        public DateTime? RentalPeriodStart { get; set; }
        public DateTime? RentalPeriodEnd { get; set; }
        public string? Remarks { get; set; }

        public bool? IsReadOnly { get; set; }
        public string? CustomerEmail { get; set; }
        public string? EmployeeName { get; set; }

        [Required]
        public int TemplateId { get; set; }

        [JsonIgnore]
        public TemplateDto? Template { get; set; }


    }
}

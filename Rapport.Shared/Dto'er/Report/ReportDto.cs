using Rapport.Shared.Dto_er.Customer;
using Rapport.Shared.Dto_er.Employee;
using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.Template;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.Report
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? RentalPeriodStart { get; set; }
        public DateTime? RentalPeriodEnd { get; set; }
        public string? Remarks { get; set; }

        public bool? IsReadOnly { get; set; }
  
        public int TemplateId { get; set; }

        [JsonIgnore]
        public TemplateDto? Template { get; set; }
   
        public int CustomerId { get; set; }
        
        [JsonIgnore]
        public CustomerDto? Customer { get; set; }

        public int EmployeeId { get; set; }
       
        [JsonIgnore]
        public EmployeeDto? Employee { get; set; }
        public ICollection<ReportGroupDto>? ReportGroups { get; set; }
    }
}

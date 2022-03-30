using Rapport.Shared.Dto_er.Customer;
using Rapport.Shared.Dto_er.Employee;
using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public TemplateDto? Template { get; set; }

        public int CustomerId { get; set; }
        public CustomerDto? Customer { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeDto? Employee { get; set; }
        public ICollection<ReportGroupDto>? ReportGroups { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rapport.Entites
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? RentalPeriodStart { get; set; }
        public DateTime? RentalPeriodEnd { get; set; }
        public string? Remarks { get; set; }

        public bool? IsReadOnly { get; set; }

        [ForeignKey( nameof(TemplateId))]
        public int TemplateId { get; set; }
        public Template? Template { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; } 
        public  ICollection<ReportGroup>? ReportGroups { get; set; }





    }
}

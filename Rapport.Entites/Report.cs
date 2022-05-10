using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rapport.Entites
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? Date { get; set; }

        public int? LayoutId { get; set; }

        public string? Remarks { get; set; }

        public bool? IsReadOnly { get; set; }

        public string? CustomerEmail { get; set; }

        public string? EmployeeName { get; set; }

        [ForeignKey( nameof(TemplateId))]
        public int TemplateId { get; set; }
        public Template? Template { get; set; }
        public  ICollection<ReportGroup>? ReportGroups { get; set; }





    }
}

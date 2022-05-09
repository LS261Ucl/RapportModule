using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rapport.Entites
{
    public class ReportElement
    {
        [Key]
        public int Id { get; set; } 
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int DataType { get; set; }
        public string? Options { get; set; }
        public string? Remarks { get; set; }
        public double Numbers { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(ReportGroupId))]
        public int ReportGroupId { get; set; }
        public ReportGroup? ReportGroup { get; set; }

        [ForeignKey(nameof(TemplateElementId))]
        public int TemplateElementId { get; set; }

        public TemplateElement? TemplateElement { get; set; }

    }
}

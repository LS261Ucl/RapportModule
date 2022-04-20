using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rapport.Entites
{
    public class ReportGroup
    {
        [Key]
        public int Id { get; set; }
        public string? Titel { get; set; }

        [ForeignKey(nameof(TemplateGroupId))]
        public int TemplateGroupId { get; set; }

        [ForeignKey(nameof(ReportId))]
        public int ReportId { get; set; }
        public Report? Report { get; set; }
        public ICollection<ReportElement>? Elements { get; set; }    
    }
}

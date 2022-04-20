using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rapport.Entites
{
    public class TemplateGroup
    {
        [Key]
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Description { get; set; }

        [ForeignKey(nameof(TemplateId))]
        public int TemplateId { get; set; }
        public Template? Template { get; set; }
        public ICollection<TemplateElement>? Elements { get; set; }
        public ICollection<ReportGroup>? ReportGroups { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rapport.Entites
{
    public class TemplateElement
    {
        [Key]
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int Datatype { get; set; }
        public string? Options { get; set; }

        [ForeignKey(nameof(TemplateGroupId))]
        public int TemplateGroupId { get; set; }
        public TemplateGroup? TemplateGroup { get; set; }
        public ICollection<ReportElement>? ReportElements { get; set; }  
    }
}

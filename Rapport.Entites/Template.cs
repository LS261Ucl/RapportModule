using System.ComponentModel.DataAnnotations;

namespace Rapport.Entites
{
    public class Template
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? LayoutId { get; set; }
        public ICollection<TemplateGroup>? TemplateGroups { get; set; }
        public ICollection<Report>? Reports { get; set; }
    


    }
}

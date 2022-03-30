using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Entites
{
    public class ReportGroup
    {
        [Key]
        public int Id { get; set; }
        public string? Titel { get; set; }

        [ForeignKey(nameof(TemplateGroupId))]
        public int TemplateGroupId { get; set; }
        public TemplateGroup? TemplateGroup { get; set; }
        public ICollection<ReportElement>? Elements { get; set; }    
    }
}

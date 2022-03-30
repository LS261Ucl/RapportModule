using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.Template;
using Rapport.Shared.Dto_er.TemplateElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Shared.Dto_er.TemplateGroup
{
    public class TemplateGroupDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Description { get; set; }  
        public int TemplateId { get; set; }
        public TemplateDto? TemplateDto { get; set; }
        public ICollection<TemplateElementDto>? Elements { get; set; }
        public ICollection<ReportGroupDto>? ReportGroups { get; set; }
    }
}

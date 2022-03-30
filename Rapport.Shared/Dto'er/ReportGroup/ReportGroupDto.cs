using Rapport.Shared.Dto_er.ReportElement;
using Rapport.Shared.Dto_er.TemplateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Shared.Dto_er.ReportGroup
{
    public class ReportGroupDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }

        public int TemplateGroupId { get; set; }
        public TemplateGroupDto? TemplateGroup { get; set; }
        public ICollection<ReportElementDto>? Elements { get; set; }
    }
}

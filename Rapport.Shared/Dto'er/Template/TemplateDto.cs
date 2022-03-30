using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.TemplateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Shared.Dto_er.Template
{
    public class TemplateDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? LayoutId { get; set; }
        public ICollection<TemplateGroupDto>? TemplateGroups { get; set; }
        public ICollection<ReportDto>? Reports { get; set; }
    }
}

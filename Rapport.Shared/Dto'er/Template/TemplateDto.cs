using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Dto_er.TemplateGroup;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.Template
{
    public class TemplateDto
    {
        public TemplateDto()
        {
            TemplateGroups = new List<TemplateGroupDto>();
        }
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public int LayoutId { get; set; }


        public ICollection<TemplateGroupDto>? TemplateGroups { get; set; }

        //[JsonIgnore]
        //public ICollection<ReportDto>? Reports { get; set; }
    }
}

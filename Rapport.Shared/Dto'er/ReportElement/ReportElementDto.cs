using Rapport.Shared.Dto_er.ReportGroup;
using Rapport.Shared.Dto_er.TemplateElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rapport.Shared.Dto_er.ReportElement
{
    public class ReportElementDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int DataType { get; set; }
        public string? Options { get; set; }
        public string? Remarks { get; set; }
        public double Numbers { get; set; }
        public byte[]? Image { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public int ReportGroupId { get; set; }
        public ReportGroupDto? ReportGroup { get; set; }

        [JsonIgnore]
        public int TemplateElementId { get; set; }

        public TemplateElementDto? TemplateElement { get; set; }
    }
}

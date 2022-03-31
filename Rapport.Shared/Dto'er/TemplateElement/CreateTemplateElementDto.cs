
using Rapport.Shared.Dto_er.TemplateGroup;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rapport.Shared.Dto_er.TemplateElement
{
    public class CreateTemplateElementDto
    {    
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int Datatype { get; set; }
        public string? Options { get; set; }

        [Required]
        public int TemplateGroupId { get; set; }

        [JsonIgnore]
        public  TemplateGroupDto? TemplateGroupDto { get; set; }
    }
}

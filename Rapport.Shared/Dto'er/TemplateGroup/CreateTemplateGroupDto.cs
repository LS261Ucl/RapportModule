using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.TemplateGroup
{
    public class CreateTemplateGroupDto
    {
        public string? Titel { get; set; }
        public string? Description { get; set; }

        [Required]
        public int TemplateId { get; set; }

    }
}

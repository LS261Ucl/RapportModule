
using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.TemplateGroup
{
    public class UpdateTemplateGroupDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Husk at Titel")]
        public string? Titel { get; set; }
        public string? Description { get; set; }
    }
}

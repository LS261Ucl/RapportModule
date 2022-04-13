using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.TemplateElement
{
    public class UpdateTemplateElementDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Husk at Titel")]
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int Datatype { get; set; }
        public string? Options { get; set; }
    }
}

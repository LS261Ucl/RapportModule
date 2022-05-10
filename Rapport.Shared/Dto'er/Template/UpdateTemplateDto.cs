
using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.Template
{
    public class UpdateTemplateDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Husk at Titel")]
        public string? Title { get; set; }
        public int LayoutId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.Template
{
    public class CreateTemplateDto
    {     
      
        public string? Title { get; set; }

        [Required ]
        public int? LayoutId { get; set; }
     
    }
}

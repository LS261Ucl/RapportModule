using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.User
{
    public class LoginDto
    {
        [Required, EmailAddress(ErrorMessage ="Tjek om Email er korrekt")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Husk Password")]
        public string? Password { get; set; }
    }
}

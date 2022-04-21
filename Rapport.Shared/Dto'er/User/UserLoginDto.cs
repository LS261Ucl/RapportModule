using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.User
{
    public class UserLoginDto
    {
    
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

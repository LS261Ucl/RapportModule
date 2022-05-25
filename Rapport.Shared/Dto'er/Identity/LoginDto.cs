using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.User
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Husk bruger navn")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Husk password")]
        public string? Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Rapport.Shared.Dto_er.User
{
    public class LoginDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

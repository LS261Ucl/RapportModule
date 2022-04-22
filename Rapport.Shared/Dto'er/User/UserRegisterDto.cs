using System.ComponentModel.DataAnnotations;


namespace Rapport.Shared.Dto_er.User
{
    public class UserRegisterDto
    {

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "Password passer ikke")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

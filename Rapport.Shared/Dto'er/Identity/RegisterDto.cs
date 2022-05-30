using System.ComponentModel.DataAnnotations;


namespace Rapport.Shared.Dto_er.User
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Husk Navn")]
        public string? FullName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Husk Email")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Husk at registre role")]
        public string? Role { get; set; }
        
        [Required (ErrorMessage = "Husk Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Password og Confirm password er ikke ens")]
        public string? ConfirmPassword { get; set; }
    }
}

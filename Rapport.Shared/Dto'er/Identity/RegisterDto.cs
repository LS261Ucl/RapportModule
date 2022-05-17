using System.ComponentModel.DataAnnotations;


namespace Rapport.Shared.Dto_er.User
{
    public class RegisterDto
    {


        [Required(ErrorMessage = "Husk Bruger navn")]
        public string? FullName { get; set; }

 
        [Required, EmailAddress]
        public string?Email { get; set; }

        [Required]
        public string? ConformPassword { get; set; }

        [Required]
        public string? Password { get; set; }

    
    }
}

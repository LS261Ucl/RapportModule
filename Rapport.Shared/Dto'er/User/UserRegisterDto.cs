using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Shared.Dto_er.User
{
    public class UserRegisterDto
    {

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "Password passer ikke")]
        public string PasswordConfirmation { get; set; } = string.Empty;
    }
}

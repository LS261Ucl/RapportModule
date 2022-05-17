using Microsoft.AspNetCore.Identity;

namespace Rapport.Entites.Identity
{
    public class AppUser 
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Role { get; set; } = "Customer";
    }
}

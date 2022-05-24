using Microsoft.AspNetCore.Identity;

namespace Rapport.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}

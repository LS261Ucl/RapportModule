using Microsoft.AspNetCore.Identity;

namespace Rapport.Entites.Identity
{
    public class UserRoles : IdentityRole
    {
        public string Admin { get; set; }
        public string User { get; set; }
    }
}

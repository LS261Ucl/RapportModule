using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Rapport.Entites.Identity;
using System.Security.Claims;

namespace Rapport.BusinessLogig.Services
{
    internal class ProfileService : IProfileService
    {
        protected UserManager<AppUser> UserManager;

        public ProfileService(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await UserManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
            {
                new Claim("DisplayName", user.DisplayName),
                new Claim("Username", user.UserName)
            };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
          var user = await UserManager.GetUserAsync(context.Subject);

            context.IsActive = user != null;
        }
    }
}

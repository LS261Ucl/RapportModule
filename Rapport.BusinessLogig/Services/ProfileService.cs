using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Rapport.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class ProfileService : IProfileService
    {

        protected UserManager<ApplicationUser> UserManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await UserManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
            {
                new Claim("Displayname", user.DisplayName),
                new Claim("Username", user.UserName)
            };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await UserManager.GetUserAsync (context.Subject);

            context.IsActive = user != null;
        }
    }
}

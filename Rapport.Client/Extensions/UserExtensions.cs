using System.Security.Claims;

namespace Rapport.Client.Extensions
{
    public static class UserExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(x => x.Type.Equals("sub"))?.Value ?? "";
        }

        public static string GetDisplayName(this ClaimsPrincipal user)
        {
            return user.FindFirst(x => x.Type == "DisplayName")?.Value!;
        }

        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(x => x.Type == "Username")?.Value!;
        }

        public static string GetToken(this ClaimsPrincipal user)
        {
            return user.FindFirst(x => x.Type == "access_token")?.Value!;
        }
    }
}

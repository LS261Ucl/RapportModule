using IdentityServer4.Models;

namespace Rapport.Server
{
    public class Config
    {

        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[] {new ApiScope("RapportAPI.read"),new ApiScope("RapportAPI.write"),};

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("RapportApi")
                {
                    Scopes = new List<string> {"RapportApi.read", "RapportApi.write"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"role" }
                }
            };


        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName ="Client Creadential Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ScopeSecret".Sha256())},
                    AllowedScopes = {"RapportApi.read", "RapportApi.write"}

                },

                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("ScopeSecret".Sha256())},
                    AllowedGrantTypes= GrantTypes.Code,
                    RedirectUris = {"https://localhost:5444/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:5444/signin-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = {"openid", "profile", "RapportAPI.read"},
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                },

            };
    }
}

using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Rapport.Client.Service
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient http)
        {
            _localStorageService = localStorageService;
            _http = http;
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            NotifyAuthenticationStateChanged(authState);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
         //   var test = _localStorageService.KeysAsync().Result;

            string authToken = await _localStorageService.GetItemAsync<string>("authToken");

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;


            if (!string.IsNullOrEmpty(authToken))
            {
                try
                {
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                    
                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
                }
                catch
                {
                    await _localStorageService.RemoveItemAsync("authToken");
                    identity = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

    

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {

            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

    }
}

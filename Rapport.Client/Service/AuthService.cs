using Rapport.Shared.Dto_er.User;
using Rapport.Shared.Response;
using System.Net.Http.Json;

namespace Rapport.Client.Service
{
    public class AuthService : IAuthService
    {

        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
                return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Kunne ikke få lov til at logge på", ex);
            }

       
        }

        public async Task<bool> IsUserAuthenticated()
        {
            try
            {
                return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
            }
            catch (Exception ex)
            {
                throw new Exception("Kunne ikke få lov til at logge på", ex);
            }

    
        }

        public async Task<ServiceResponse<string>> Login(LoginDto request)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("/auth/login", request);
                return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            }
            catch(Exception ex)
            {
                throw new Exception("Kunne ikke få lov til at logge på", ex);
            }
  
        }

        public async Task<ServiceResponse<int>> Register(RegisterDto request)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/auth/register", request);
                return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Kunne ikke få lov til at logge på", ex);
            }

        }
    }
}

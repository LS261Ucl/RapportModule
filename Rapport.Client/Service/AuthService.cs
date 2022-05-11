using Rapport.Shared.Dto_er.User;
using Rapport.Shared.Response;
using System.Net.Http.Json;

namespace Rapport.Client.Service
{
    public class AuthService : IAuthService
    {

        private readonly HttpClient _http;
        private readonly IHttpService _httpService;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, 
            IHttpService httpService,
            AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _httpService = httpService;
            _authStateProvider = authStateProvider;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
        {
            var result = await _http.PostAsJsonAsync("auth/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<LoginDto> Login(LoginDto requestDto)
        {
            try
            {
                var wrapper = await _httpService.Post<LoginDto, LoginDto>("auth/login", requestDto);
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Fikk ikke lov til logge ind");
            }
        }

        public async Task<RegisterDto> RegisterUser(RegisterDto requestDto)
        {

            try
            {

                var wrapper = await _httpService.Post<RegisterDto, RegisterDto>("auth/register", requestDto);
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("unable to get httpservice", ex);
            }

        }
    }
}

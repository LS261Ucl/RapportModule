using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rapport.Shared.Dto_er.Identity;
using Rapport.Shared.Dto_er.User;

namespace Rapport.Client.Service
{
    public class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(IHttpService httpService, AuthenticationStateProvider authStateProvider)
        {
            _httpService = httpService;
            _authStateProvider = authStateProvider;
        }

        public async Task<UserDto> Login(LoginDto login)
        {
            var wrapper = await _httpService.Post<LoginDto, UserDto>($"auth/login", login);
            return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
        }

        public async Task<UserDto> Register(RegisterDto register)
        {
            var wrapper = await _httpService.Post<RegisterDto, UserDto>($"auth/registre", register);
            return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
        }
    }
}

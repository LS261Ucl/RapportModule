using Rapport.Shared.Dto_er.User;
using Rapport.Shared.Response;

namespace Rapport.Client.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginDto> LoginAsync(LoginDto user);
        public Task<RegisterDto> RegisterUserAsync(RegisterDto user);
        public Task<LoginDto> GetUserByAccessTokenAsync(string accessToken);
        public Task<LoginDto> RefreshTokenAsync(RefreashRequest refreshRequest);
    }
}

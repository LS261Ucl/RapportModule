using Rapport.Shared.Dto_er.User;
using Rapport.Shared.Response;

namespace Rapport.Client.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterDto> RegisterUser(RegisterDto requestDto);

        Task<LoginDto> Login(LoginDto requestDto);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<bool> IsUserAuthenticated();
    }
}

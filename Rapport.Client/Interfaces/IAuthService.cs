using Rapport.Shared.Dto_er.User;
using Rapport.Shared.Response;

namespace Rapport.Client.Interfaces
{
    public interface IAuthService
    {
      //  Task<ServiceResponse<int>> Register(UserRegisterDto request);
        Task<UserRegisterDto> RegisterUser(UserRegisterDto requestDto);

        Task<UserLoginDto> Login(UserLoginDto requestDto);

        //Task<ServiceResponse<string>> Login(UserLoginDto request);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<bool> IsUserAuthenticated();
    }
}

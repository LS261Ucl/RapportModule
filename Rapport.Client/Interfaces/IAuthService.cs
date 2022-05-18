using Rapport.Shared.Dto_er.User;
using Rapport.Shared.Response;

namespace Rapport.Client.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(RegisterDto request);
        Task<ServiceResponse<string>> Login(LoginDto request);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<bool> IsUserAuthenticated();
    }
}

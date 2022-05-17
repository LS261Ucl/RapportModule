using Rapport.Entites.Identity;
using Rapport.Shared.Response;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(AppUser user, string password);
        Task<bool> UserExists(string email);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
        int GetUserId();
        string GetUserEmail();
        Task<AppUser> GetUserByEmail(string email);
    }
}

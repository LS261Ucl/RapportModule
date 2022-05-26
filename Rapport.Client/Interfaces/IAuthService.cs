using Rapport.Shared.Dto_er.Identity;
using Rapport.Shared.Dto_er.User;
using Rapport.Shared.Response;

namespace Rapport.Client.Interfaces
{
    public interface IAuthService
    {
        public Task<UserDto> Login(LoginDto login);
        public Task<UserDto> Register (RegisterDto register);
    }
}

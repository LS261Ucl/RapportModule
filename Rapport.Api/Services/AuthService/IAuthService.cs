﻿using Rapport.Entites.Identity;
using Rapport.Shared.Response;

namespace Rapport.Api.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password, string role);
        Task<bool> UserExists(string email);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
        int GetUserId();
        string GetUserEmail();
        Task<User> GetUserByEmail(string email);
    }
}

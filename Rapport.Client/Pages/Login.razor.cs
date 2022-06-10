﻿using Microsoft.AspNetCore.Components;
using Rapport.Client.Service;
using Rapport.Shared.Dto_er.User;
using System.Security.Claims;

namespace Rapport.Client.Pages
{
    public partial class Login
    {
        private LoginDto? user;
        public string? LoginMesssage { get; set; }
        ClaimsPrincipal? claimsPrincipal;

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationStateTask { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        [Inject]
        private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        [Inject]
        private IAuthService? AuthService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            user = new LoginDto();

            claimsPrincipal = (await authenticationStateTask).User;

            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/index");
            }

        }

        private async Task<bool> ValidateUser()
        {
            //assume that user is valid
            //call an API

            var returnedUser = await AuthService.Login(user);

            if (returnedUser?.Token != null)
            {
                await ((CustomAuthStateProvider?)AuthenticationStateProvider)?.GetAuthenticationStateAsync();
                NavigationManager.NavigateTo("/index");
            }
            else
            {
                LoginMesssage = "Invalid username or password";
            }

            return await Task.FromResult(true);
            }
        }
}

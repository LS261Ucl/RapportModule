using Microsoft.AspNetCore.Components;
using Rapport.Client.Service;
using Rapport.Shared.Dto_er.User;

namespace Rapport.Client.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        private IAuthService authService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private RegisterDto RegisterDto { get; set; }
        public string LoginMesssage { get; set; }

        protected override Task OnInitializedAsync()
        {
            user = new RegisterDto();
            return base.OnInitializedAsync();
        }

        private async Task<bool> RegisterUser()
        {
            //assume that user is valid
            var returnedUser = await authService.Register(user);

            if (returnedUser.Token != null)
            {
                ((CustomAuthStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
                NavigationManager.NavigateTo("/");
            }
            else
            {
                LoginMesssage = "Invalid username or password";
            }

            return await Task.FromResult(true);
        }
    }
}

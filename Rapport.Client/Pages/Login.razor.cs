using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Rapport.Client.Service;
using Rapport.Shared.Dto_er.User;
using System.Net.Http.Json;
using System.Security.Claims;


namespace Rapport.Client.Pages
{
    public partial class Login
    {
        private LoginDto? user;
        public string? LoginMesssage { get; set; }
        ClaimsPrincipal? claimsPrincipal;

        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        [Inject]
        private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        [Inject]
        private IAuthService? AuthService { get; set; }

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        [Inject]
        private HttpClient Http { get; set; }



        protected async override Task OnInitializedAsync()
        {
            user = new LoginDto();

            //claimsPrincipal = (await AuthenticationStateTask).User;

            //if (claimsPrincipal.Identity.IsAuthenticated)
            //{
            //    NavigationManager.NavigateTo("/index");
            //}

        }

        private async Task ValidateUser()
        {
            //assume that user is valid
            //call an API

            //var returnedUser = await AuthService.Login(user);

            //if (returnedUser?.Token != null)
            //{
            //   await LocalStorage.GetItemAsStringAsync(returnedUser.Token);
            //   await ((CustomAuthStateProvider?)AuthenticationStateProvider)?.GetAuthenticationStateAsync();
            //   NavigationManager.NavigateTo("/index");
            //}
            //else
            //{
            //    LoginMesssage = "Invalid username or password";
            //}



            var result = await Http.PostAsJsonAsync($"http://localhost:5002/api/auth/login", user);
            var token = await result.Content.ReadAsStringAsync();
            Console.WriteLine(token);
            await LocalStorage.SetItemAsync("token", token);
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("/index");

        }
    }
}

using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace Rapport.Client.Shared
{
    public partial class UserButton : ComponentBase
    {
        [Inject]
        private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private ILocalStorageService? LocalStorage { get; set; }

        private bool showUserMenu = false;

        private string UserMenuCssClass => showUserMenu ? "show-menu" : null;

        private void ToggleUserMenu()
        {
            showUserMenu = !showUserMenu;
        }

        private async Task HideUserMenu()
        {
            await Task.Delay(200);
            showUserMenu = false;
        }

        private async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("authToken");
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("/");
        }
    }
}

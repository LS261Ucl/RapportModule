//using Rapport.Shared.Dto_er.User;

//namespace Rapport.Client.Pages
//{
//    public partial class SignUp
//    {
//        private RegisterDto user { get; set; }
//        public string LoginMesssage { get; set; }

//        protected override Task OnInitializedAsync()
//        {
//            user = new RegisterDto();
//            return base.OnInitializedAsync();
//        }

//        private async Task<bool> RegisterUser()
//        {
//            //assume that user is valid

//            var returnedUser = await authService.RegisterUserAsync(user);

//            if (returnedUser.Username != null)
//            {
//                ((CustomAuthStateProvider).AuthenticationStateProvider).MarkUserAsAuthenticated(returnedUser);
//                NavigationManager.NavigateTo("/");
//            }
//            else
//            {
//                LoginMesssage = "Invalid username or password";
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}

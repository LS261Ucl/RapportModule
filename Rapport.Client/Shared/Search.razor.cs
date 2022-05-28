using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Rapport.Client.Shared
{
    public partial class Search : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IReportService _service { get; set; }

        private string searchText = string.Empty;

        private List<string> suggestions = new List<string>();

        protected ElementReference searchInput;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await searchInput.FocusAsync();
            }
        }

        public void SearchReports()
        {
            NavigationManager.NavigateTo($"search/{searchText}/1");
        }

        public async Task HandleSearch(KeyboardEventArgs args)
        {
            if (args.Key == null || args.Key.Equals("Enter"))
            {
                SearchReports();
            }
            else if (searchText.Length > 1)
            {
                
            }
        }
    }
}

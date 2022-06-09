using Microsoft.AspNetCore.Components;

namespace Rapport.Client.Pages
{
    public partial class Reports : ComponentBase
    {
        public  List<ReportDto>? reportList = new List<ReportDto>();

        public ReportDto ReportDto { get; set; } = new ReportDto();

        public bool isLoading = true;

        [Inject]
        private IReportService? _reportService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            reportList = await _reportService.GetReports();
            _reportService.OnChange += StateHasChanged;

            isLoading = false;
           
        }

        public async Task HandleValidSubmit(int id)
        {
           
            NavigationManager.NavigateTo($"report/{id}");
        }

      
    }
}

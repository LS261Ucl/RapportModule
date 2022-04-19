using Microsoft.AspNetCore.Components;


namespace Rapport.Client.Pages
{
    public partial class Reports : ComponentBase
    {
        public  List<ReportDto>? reportList = new List<ReportDto>();

        public ReportDto reportDto { get; set; } = new ReportDto();

        [Inject]
        private IReportService? _reportService { get; set; }

        //[Inject]
        //private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            reportList = await _reportService.GetReports();
            _reportService.OnChange += StateHasChanged; 
           
        }
    }
}

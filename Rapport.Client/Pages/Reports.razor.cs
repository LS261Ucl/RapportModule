using Microsoft.AspNetCore.Components;
using Rapport.Client.Shared;

namespace Rapport.Client.Pages
{
    public partial class Reports : ComponentBase
    {
        public  List<ReportDto>? reportList = new List<ReportDto>();
        public IEnumerable<ReportDto> reports = Enumerable.Empty<ReportDto>();

        public ReportDto ReportDto { get; set; } = new ReportDto();

        public bool isLoading = true;

        // private int pageIndex = 1;
        private int itemsPerPage = 5;
        private int totalPages = 1;

        [Inject]
        private IReportService? _reportService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private PageIndexStateProvider State { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            reportList = await _reportService.GetReports();
            _reportService.OnChange += StateHasChanged;

            //if (reportList != null)
            //{
            //    // Initialize the number of "totalPages"
            //    totalPages = (int)(reportList.Count() / itemsPerPage);

            //    // Initialize the "comments" which will be displayed when the page loaded first time.
            //    var skipCount = itemsPerPage * (State.PageIndex - 1);
            //    reports = reportList.Skip(skipCount).Take(itemsPerPage);
            //}
       
            isLoading = false;           
        }

        public async Task HandleValidSubmit(int id)
        {
           
            NavigationManager.NavigateTo($"report/{id}");
        }


        private void SelectedPage(int selectedPageIndex)
        {
            if (reportList != null)
            {
                State.PageIndex = selectedPageIndex;
                var skipCount = itemsPerPage * (State.PageIndex - 1);
                reports = reportList.Skip(skipCount).Take(itemsPerPage);
            }
        }

    }
}

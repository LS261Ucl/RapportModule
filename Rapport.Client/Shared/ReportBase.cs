using Microsoft.AspNetCore.Components;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.Client.Shared
{
    public class ReportBase : ComponentBase
    {

        [Inject]
        private IReportService? ReportService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        public ReportDto reportDto { get; set; } = new();


        private ReportElementDto ElementDto { get; set; } = new();

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        protected override async Task OnInitializedAsync()
        {
            reportDto = await ReportService.GetReportWhitGroupsAndFields(Id);
            if(reportDto != null && reportDto.LayoutId == 1)
            {
                NavigationManager.NavigateTo("/preparationreport");
            }
            if(reportDto != null && reportDto.LayoutId == 2)
            {
                NavigationManager.NavigateTo("/cleaningreport");
            }

            ReportService.OnChange += StateHasChanged;
        }

        protected override async Task OnParametersSetAsync()
        {
            reportDto = await ReportService.GetReportWhitGroupsAndFields(Id);
            ReportService.OnChange += StateHasChanged;
        }



    }
}

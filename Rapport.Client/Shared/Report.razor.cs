using Microsoft.AspNetCore.Components;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.Client.Shared
{
    public partial class Report : ComponentBase
    {
        [Inject]
        private IReportService ReportService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        public ReportDto ReportDto { get; set; } = new();

        private ReportElementDto ElementDto { get; set; } = new();

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        protected override async Task OnInitializedAsync()
        {
            ReportDto = await ReportService.GetReportWhitGroupsAndFields(Id);
            ReportService.OnChange += StateHasChanged;
        }

        protected override async Task OnParametersSetAsync()
        {
            ReportDto = await ReportService.GetReportWhitGroupsAndFields(Id);
            ReportService.OnChange += StateHasChanged;
        }

        //for lavet en cyklus
        public async Task<ReportDto> ValidSubmit(ReportDto currentReportDataDto)
        {
            try
            {
                //Api call whit Update
                var dbReport = await ReportService.UpdatedReport(Id, currentReportDataDto);
                return dbReport;

            }
            catch (Exception ex)
            {
                throw new Exception($"kunne ikke få lov til at gemme følgende skabelon: {Id}", ex);
            }

        }

        public async Task DeleteReport(int id)
        {
            await ReportService.DeletedReport(Id);
            NavigationManager.NavigateTo("reports");

        }

    }
}

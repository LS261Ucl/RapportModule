using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Rapport.Shared.Dto_er.Image;
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
                NavigationManager.NavigateTo($"/report/preparation/{reportDto.Id}");
            }
            if(reportDto != null && reportDto.LayoutId == 2)
            {
                NavigationManager.NavigateTo($"/report/cleaning/{reportDto.Id}");
            }

            ReportService.OnChange += StateHasChanged;
        }

        protected override async Task OnParametersSetAsync()
        {
            reportDto = await ReportService.GetReportWhitGroupsAndFields(Id);
            ReportService.OnChange += StateHasChanged;
        }

        private async Task OnFileChange(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            foreach (var image in e.GetMultipleFiles(int.MaxValue))
            {
                var resizedImage = await image.RequestImageFileAsync(format, 200, 200);
                var buffer = new byte[resizedImage.Size];
                await resizedImage.OpenReadStream().ReadAsync(buffer);
                var imageDate = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                reportDto.Images.Add(new ImageDto { Img = imageDate});
            }
 
        }

        public async Task SendMail()
        {
            NavigationManager.NavigateTo("/mail");
        }
    }

}

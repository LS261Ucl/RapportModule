using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Rapport.Client.Extensions;
using Rapport.Client.Service;
using Rapport.Shared.Dto_er.Image;
using System.IO;

namespace Rapport.Client.Shared
{
    public class ReportBase : ComponentBase
    {

        [Inject]
        private IReportService? ReportService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Inject]
        private PdfExportService pdfExportService { get; set; }

        [Inject]
        private Microsoft.JSInterop.IJSRuntime js { get; set; }

        [Parameter]
        public int Id { get; set; }

        public ReportDto reportDto { get; set; } = new();
        private ReportDto[] Reports { get; set; }
       public bool isLoading = true;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            reportDto = await ReportService.GetReportWhitGroupsAndFields(Id);
            if(reportDto != null && reportDto.LayoutId == 1)
            {
                NavigationManager.NavigateTo($"/report/preparation/{reportDto.Id}");
            }
            if(reportDto != null && reportDto.LayoutId == 2)
            {
                NavigationManager.NavigateTo($"/report/cleaning/{reportDto.Id}");
            }
            if(reportDto != null && reportDto.LayoutId == 3)
            {
                NavigationManager.NavigateTo($"/report/repair/{reportDto.Id}");
            }

            ReportService.OnChange += StateHasChanged;

            isLoading = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            reportDto = await ReportService.GetReportWhitGroupsAndFields(Id);
            ReportService.OnChange += StateHasChanged;
        }

        public async Task OnFileChange(InputFileChangeEventArgs e)
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

       public void RemoveImage(int id)
        {
            var image = reportDto.Images.FirstOrDefault(i => i.Id == id);
            if (image != null)
            {
                reportDto.Images.Remove(image);
            }
        }

        public async Task SendMail()
        {
            NavigationManager.NavigateTo("/mail");
        }

        public async Task Save(int id)
        {
            try
            {
                await ReportService.UpdatedReport(reportDto.Id, reportDto);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected async Task ExportToPdf()
        {
           using(MemoryStream memoryStream = pdfExportService.CreatePdf(Reports))
            {
                await js.SaveAs("Rapport.pdf", memoryStream.ToArray());
            }
        }

    }

}

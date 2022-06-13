using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Rapport.Shared.Dto_er.Image;
using Rapport.Client.Extensions;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Rapport.Client.Shared
{
    public class ReportBase : ComponentBase
    {

        [Inject]
        public IReportService? ReportService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

  

        [Inject]
        private IJSRuntime js { get; set; }

        [Parameter]
        public int Id { get; set; }

        public ReportDto reportDto { get; set; } = new();
     
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
            else
            {
                NavigationManager.NavigateTo($"/report/cleaning/{reportDto.Id}");
            }
            //else(reportDto != null && reportDto.LayoutId == 3)
            //{
            //    NavigationManager.NavigateTo($"/report/repair/{reportDto.Id}");
            //}

            ReportService.OnChange += StateHasChanged;

            isLoading = false;
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

       public void Print()
        {
            js.InvokeVoidAsync("Print");
        }

        public async Task ExportToPdf(int id)
        {
            //var test = 1;
            //var rapId = reportDto.Id;




            int paragraphAfterSpacing = 8;
            int cellMargin = 8;
            PdfDocument pdfDocument = new PdfDocument();
            //Add Page to the PDF document.
            PdfPage page = pdfDocument.Pages.Add();

            //Create a new font.
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

            //Create a text element to draw a text in PDF page.
            PdfTextElement title = new PdfTextElement(reportDto.Title, font, PdfBrushes.Black);
            PdfLayoutResult result = title.Draw(page, new PointF(0, 0));


            PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);


            PdfTextElement content = new PdfTextElement("Hello world", contentFont, PdfBrushes.Black);
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            //Draw a text to the PDF document.
            result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

            //Create a PdfGrid
            PdfGrid pdfGrid = new PdfGrid();
            pdfGrid.Style.CellPadding.Left = cellMargin;
            pdfGrid.Style.CellPadding.Right = cellMargin;

            //Applying built-in style to the PDF grid
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

            //Assign data source.
            pdfGrid.DataSource = reportDto;

            pdfGrid.Style.Font = contentFont;

            //Draw PDF grid into the PDF page.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

            MemoryStream memoryStream = new MemoryStream();

            // Save the PDF document.
            pdfDocument.Save(memoryStream);

            // Download the PDF document
            js.SaveAs("Sample.pdf", memoryStream.ToArray());
        }
    }


}



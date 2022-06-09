using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Rapport.Client.Service
{
    public class PdfExportService
    {

        public MemoryStream CreatePdf(ReportDto[] report)
        {
            if(report == null)
            {
                throw new ArgumentNullException("report eksistere ikke");
            }
            

            //Create a new PDF document
            using(PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int celMargin = 8;

                //Add page to the pdf document
                PdfPage page = pdfDocument.Pages.Add();

                //Create new Font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text to draw a text in PDF page
                PdfTextElement titel = new PdfTextElement("Rapporter", font, PdfBrushes.Black);
                PdfLayoutResult result = titel.Draw(page, new Syncfusion.Drawing.PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                // Create a Pdf
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = celMargin;
                pdfGrid.Style.CellPadding.Right = celMargin;

                //Applying built in style to the Pdf grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable1LightAccent4);

                //Assing Data source
                pdfGrid.DataSource = report;

                pdfGrid.Style.Font = contentFont;

                //Draw pdf Grid into the pdf Page
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                using(MemoryStream stream = new MemoryStream())
                {
                    pdfDocument.Save(stream);
                    pdfDocument.Close(true);
                    return stream;
                }


            }


        }
        
    }
}

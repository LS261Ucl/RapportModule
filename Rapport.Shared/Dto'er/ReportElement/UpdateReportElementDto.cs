
namespace Rapport.Shared.Dto_er.ReportElement
{
    public class UpdateReportElementDto
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Description { get; set; }
        public int DataType { get; set; }
        public string? Options { get; set; }
        public string? Remarks { get; set; }
        public double Numbers { get; set; }
        public byte[]? Image { get; set; }
        public bool IsActive { get; set; }
    }
}

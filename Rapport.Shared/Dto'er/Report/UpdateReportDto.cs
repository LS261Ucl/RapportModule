
namespace Rapport.Shared.Dto_er.Report
{
     public class UpdateReportDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? RentalPeriodStart { get; set; }
        public DateTime? RentalPeriodEnd { get; set; }
        public string? Remarks { get; set; }

        public bool? IsReadOnly { get; set; }
        public string? CustomerEmail { get; set; }
    }
}

using Rapport.Shared.Dto_er.Report;

namespace Rapport.Shared.Dto_er.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<ReportDto>? Reports { get; set; }
   
    }
}

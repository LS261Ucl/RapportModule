using Rapport.Shared.Dto_er.Report;

namespace Rapport.Shared.Dto_er.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<ReportDto>? Reports { get; set; }
    }
}

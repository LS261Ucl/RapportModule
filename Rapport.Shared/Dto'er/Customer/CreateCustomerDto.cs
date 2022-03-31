
namespace Rapport.Shared.Dto_er.Customer
{
    public class CreateCustomerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int PostNumber { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}

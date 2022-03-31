using System.ComponentModel.DataAnnotations;

namespace Rapport.Entites
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }  
        public string? LastName { get; set; }    
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int PostNumber { get; set; }
        public string? City { get; set; }

        public string? Country { get; set; }    

        public ICollection<Report>? Reports { get; set; }    
        
    }
}

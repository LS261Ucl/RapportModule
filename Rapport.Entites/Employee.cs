using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Entites
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }    
        public string? Email { get; set; }
        public ICollection<Report>? Reports { get; set; }

    }
}

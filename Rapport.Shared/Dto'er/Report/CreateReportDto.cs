using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Shared.Dto_er.Report
{
    public class CreateReportDto
    {
        public string? Title { get; set; }
        public DateTime? RentalPeriodStart { get; set; }
        public DateTime? RentalPeriodEnd { get; set; }
        public string? Remarks { get; set; }

        public bool? IsReadOnly { get; set; }

    }
}

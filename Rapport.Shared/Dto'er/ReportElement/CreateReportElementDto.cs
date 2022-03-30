using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.Shared.Dto_er.ReportElement
{
    public class CreateReportElementDto
    {

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

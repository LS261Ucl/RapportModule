using Microsoft.AspNetCore.Http;

namespace Rapport.Entites
{
    public class EmilFileAttachment
    {
        public IFormFile DataFile { get; set; }
        public string ToEmail { get; set; }
    }
}

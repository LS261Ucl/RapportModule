using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Shared.Dto_er.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class ImageService : IImageService
    {
        public Task<ImageDto> CreateReportElement([FromBody] CreateImageDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> GetImageById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> UpdateImageById(int id, ImageDto imageDto)
        {
            throw new NotImplementedException();
        }
    }
}

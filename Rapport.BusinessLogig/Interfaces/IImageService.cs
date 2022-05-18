using Microsoft.AspNetCore.Mvc;
using Rapport.Shared.Dto_er.Image;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IImageService
    {
        Task<ImageDto> GetImageById(int id);
        Task<ImageDto> CreateReportElement([FromBody] CreateImageDto requestDto);

        Task<ImageDto> UpdateImageById(int id, ImageDto imageDto);
        Task DeleteReportElement(int id);
    }
}

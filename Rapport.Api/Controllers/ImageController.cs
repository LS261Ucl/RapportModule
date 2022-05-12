using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IGenericRepository<Image>? _imageReporsitory; 
        private readonly ILogger<ImageController>? _logger;
        private readonly IMapper _mapper;

        public ImageController(IGenericRepository<Image> imageReporsitory, ILogger<ImageController> logger, IMapper mapper)
        {
            _imageReporsitory = imageReporsitory;
            _logger = logger;
            _mapper = mapper;
        }



    }
}

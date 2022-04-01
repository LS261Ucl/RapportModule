using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateElement;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateElementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TemplateElementController> _logger;
        private readonly IGenericRepository<TemplateElement> _templateElementRepository;
        private readonly ITemplateElementService _templateElementService;
        public TemplateElementController(IGenericRepository<TemplateElement> templateElementRepository, 
            ITemplateElementService templateElementService,
            IMapper mapper,
            ILogger<TemplateElementController> logger)
        {
            _templateElementRepository = templateElementRepository;
            _templateElementService = templateElementService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemplateElementDto>>> GetTemplateElementssAsync()
        {
            try
            {
                var templateElements = await _templateElementService.GetTemplateElements();

                if (templateElements == null)
                {
                    _logger.LogError("Unable to find Templates");
                    return NotFound();
                }//if

                return Ok(templateElements);
            }//if
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//cathc
        }

        [HttpGet("{id}/groups")]
        public async Task<ActionResult<TemplateElementDto>> GetTemplateElementById(int id)
        {
            try
            {
                var templateElement = await _templateElementService.GetTemplateElementById(id);
                if (templateElement == null)
                {
                    _logger.LogError($"Unable to find template{nameof(TemplateElement)} whit this id: {id}");
                    return NotFound();
                }//if

                return Ok(templateElement);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPost]
        public async Task<ActionResult<TemplateElement>> CreateTemplateElementAsync([FromBody] CreateTemplateElementDto requestDto)
        {
            try
            {
                var templateElement = await _templateElementService.CreateTemplateElement(requestDto);

                if (templateElement == null)
                {
                    _logger.LogError("Unable to create templateelement");
                    return BadRequest();
                }//if

                return Ok(templateElement);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TemplateElement>> UpdateTemplateElementAsync(int id, UpdateTemplateElementDto requestDto)
        {
            try
            {
                var templateElement = await _templateElementService.UpdateTemplateElement(id, requestDto);

                if (templateElement == null)
                {
                    _logger.LogError($"Unable to update {nameof(TemplateElement)} whit this id: {id}");
                    return BadRequest();
                }//if

                return Ok(templateElement);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTemplateElementAsync(int id)
        {

            try
            {
                bool delete = await _templateElementRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(TemplateElement)} whit this id : {id}");
                    return NotFound();
                }//if

                return NoContent();
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }


    }
}

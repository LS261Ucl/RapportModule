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
     
        private readonly ILogger<TemplateElementController> _logger;
        private readonly IGenericRepository<TemplateElement> _templateElementRepository;
        private readonly ITemplateElementService _templateElementService;   
        public TemplateElementController(IGenericRepository<TemplateElement> templateElementRepository, 
            ITemplateElementService templateElementService,
            ILogger<TemplateElementController> logger)
        {
            _templateElementRepository = templateElementRepository;
            _templateElementService = templateElementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemplateElementDto>>> GetTemplateElementssAsync()
        {
            try
            {
                var elements = await _templateElementRepository.GetAllAsync();

                if(elements == null)
                {
                    _logger.LogError("Kunne ikke finde elementerne");
                    return NotFound();  
                }

                return Ok(elements);
            }//if
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//cathc
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateElementDto>> GetTemplateElementById(int id)
        {
            try
            {
                var element = await _templateElementService.GetTemplateElementById(id);

                if(element == null)
                {
                    _logger.LogError($"Kunne ikke finde element {nameof(TemplateElement)} med følgende Id: {id}");
                    return NotFound();
                }

                return Ok(element);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPost("{id}")]
        public async Task<ActionResult<TemplateElement>> CreateTemplateElementAsync([FromBody] CreateTemplateElementDto requestDto)
        {
            try
            {
                var created = await _templateElementService.CreateTemplateElement(requestDto);

                if(created == null)
                {
                    _logger.LogError("Kunne ikke få lov til at oprette element");
                    return BadRequest();
                }

                return Ok(created);

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
                await _templateElementService.DeleteTemplateElement(id);

              

                return NoContent();
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }


    }
}

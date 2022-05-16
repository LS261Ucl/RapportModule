using AutoMapper;
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
                var elements = await _templateElementRepository.GetAllAsync();

                if(elements == null)
                {
                    _logger.LogError("Kunne ikke finde elementerne");
                    return NotFound();  
                }

                return Ok(_mapper.Map<TemplateElement>(elements));
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTemplateElementAsync(int id, TemplateElementDto requestDto)
        {
            try
            {
                var templateElement = await _templateElementRepository.GetAsync(x => x.Id == id);

                if(templateElement == null)
                {
                    _logger.LogError($"Kunne ikke finde {nameof(templateElement)} med følgende id: {id}");
                    return NotFound();
                }

                _mapper.Map(requestDto, templateElement);

                var dbRequest = await _templateElementRepository.UpdateAsync(templateElement);

                return Ok(_mapper.Map<TemplateElement>(templateElement));
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
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

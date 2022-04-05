using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IGenericRepository<Template> _templateRepository;
        private readonly ITemplateService _templateService;
        private readonly ILogger<TemplateController> _logger;
        private readonly IMapper _mapper;

        public TemplateController(IGenericRepository<Template> templateRepository,
            ITemplateService templateService,
            ILogger<TemplateController> logger,
            IMapper mapper)
        {
            _templateRepository = templateRepository;
            _templateService = templateService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemplateDto>>> GetTemplatesAsync()
        {
            try
            {
                var templates = await _templateService.GetAllTemplate();

                if(templates == null)
                {
                    _logger.LogError("Unable to find Templates");
                    return NotFound();
                }//if

                return Ok(templates);
            }//if
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//cathc
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateDto>> GetTemplateByIdAsync(int id)
        {
            try
            {
                var dbtemplate = await _templateRepository.GetAsync(x => x.Id == id);

                if(dbtemplate == null)
                {
                    _logger.LogError($"Unable to find template whit this id: {id}");
                    return NotFound();  
                }//if

                return Ok(_mapper.Map<Template>(dbtemplate));
            }//try
            catch(Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpGet("{id}/groups")]
        public async Task<ActionResult<TemplateDto>> GetTemplateWhitChildrenAscyn(int id)
        {
            try
            {
                var dbTemplate = await _templateService.GetTemplateWhitChilderen(id);

                if(dbTemplate == null)
                {
                    _logger.LogError($"Unable to find template whit this id: {id}");
                    return NotFound();
                }//if

                return Ok(dbTemplate);
                   
            }//try
            catch(Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPost]
        public async Task<ActionResult<Template>> CreateTemplateAsync([FromBody] CreateTemplateDto requestDto)
        {
            try
            {
                var template = await _templateService.CreateTemplate(requestDto);

                if (template == null)
                {
                    _logger.LogError("Unable to create template");
                    return BadRequest();
                }//if

                return Ok(template);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Template>> UpdateTemplateAsync(int id, UpdateTemplateDto requestDto)
        {
            try
            {
                var dbTemplate = await _templateService.UpdateTemplate(id,requestDto);

                if(dbTemplate == null)
                {
                    _logger.LogError($"Unable to update template whit this id: {id}");
                    return BadRequest();
                }//if

                return Ok(dbTemplate);
            }//try
            catch(Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }
           
        [HttpDelete]
        public async Task<ActionResult> DeleteTemplateAsync(int id)
        {

            try
            {
                bool delete = await _templateRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(Template)} whit this id : {id}");
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

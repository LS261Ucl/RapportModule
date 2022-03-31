using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;
using System.Resources;

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
                }

                return Ok(templates);
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }

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
                }

                return Ok(_mapper.Map<Template>(dbtemplate));
            }
            catch(Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }
        }

        [HttpGet("{id}/groups{id}/fields{id}")]
        public async Task<ActionResult<TemplateDto>> GetTemplateWhitChildrenAscyn(int id)
        {
            try
            {
                var dbTemplate = await _templateService.GetTemplateWhitChilderen(id);

                if(dbTemplate == null)
                {
                    _logger.LogError($"Unable to find template whit this id: {id}");
                    return NotFound();
                }

                return Ok(dbTemplate);
                   
            }
            catch(Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }


        }
           

    }
}

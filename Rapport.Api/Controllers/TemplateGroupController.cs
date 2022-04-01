using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateGroup;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateGroupController : ControllerBase
    {
        private readonly IGenericRepository<TemplateGroup> _templateGroupRepository;
        private readonly ITemplateGroupService _templateGroupService;
        private readonly ILogger<TemplateGroupController> _logger;
        private readonly IMapper _mapper;

        public TemplateGroupController(IGenericRepository<TemplateGroup> templateGroupRepository, 
            ITemplateGroupService templateGroupService,
            ILogger<TemplateGroupController> logger,
            IMapper mapper)
        {
            _templateGroupRepository = templateGroupRepository;
            _templateGroupService = templateGroupService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemplateGroupDto>>> GetTemplateGroups()
        {
             var templateGroups = await _templateGroupService.GetTemplateGroups();

            
             if (templateGroups == null)
             {
                _logger.LogError("Unable to get TemplateGroups");
                return NotFound();
             }

             return Ok(templateGroups);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateGroupDto>> GetTemplateGroup(int id)
        {
            var templateGroup = await _templateGroupService.GetTemplateGroupById(id);

            if(templateGroup == null)
            {
                _logger.LogError($"Unable to find TemplateGroup whit this id: {id}");
                return NotFound();
            }

            return Ok(templateGroup);
        }

        [HttpPost]
        public async Task<ActionResult<TemplateGroup>> CreateTemplateGroup([FromBody] CreateTemplateGroupDto requestDto)
        {
            if (requestDto == null)
            {
                return BadRequest();
            }
            else
            {
                var templateGroup = await _templateGroupService.CreateTemplateGroup(requestDto);

                return Ok(templateGroup);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TemplateGroup>> UpdateTemplateGroup(int id,UpdateTemplateGroupDto requestDto)
        {
            var templateGroup = await _templateGroupService.UpdateTemplateGroup(id, requestDto);

            if (templateGroup == null)
            {
                return BadRequest();
            }

            return Ok(requestDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTemplateGroup(int id)
        {

            try
            {
                bool delete = await _templateGroupRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(TemplateGroup)} whit this id : {id}");
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

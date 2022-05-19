using AutoMapper;
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
        private readonly ITemplateGroupService _templateGroupService;
        private readonly ILogger<TemplateGroupController> _logger;
        private readonly IMapper _mapper;

        public TemplateGroupController(
            ITemplateGroupService templateGroupService, 
            ILogger<TemplateGroupController> logger,
            IMapper mapper)
        {
            _templateGroupService = templateGroupService;
            _logger = logger;
            _mapper = mapper;
        }

       

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateGroupDto>> GetTemplateGroup(int id)
        {
            try
            {
                var templateGroup = await _templateGroupService.GetTemplateGroupById(id);

                if (templateGroup == null)
                {
                    _logger.LogError($"Kunne ikke finde {nameof(TemplateGroup)} med følgende Id: {id}");
                    return NotFound();
                }

                return Ok(templateGroup);
            }
            catch(Exception ex)
            {
                throw new Exception($"fejl på Api,et", ex);
            }
           
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<TemplateGroup>> CreateTemplateGroup([FromBody] CreateTemplateGroupDto requestDto)
        {
            try
            {
               

                var request = await _templateGroupService.CreateTemplateGroup(requestDto);
                
                if(request == null)
                {
                    _logger.LogError($"Kunne ikke få lov til at oprette følgende gruppe {nameof(TemplateGroup)}");
                    return BadRequest();
                }

                return Ok(request);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Api", ex);
            }//catch
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTemplateGroup(int id, TemplateGroupDto requestDto)
        {
            try 
            {
                var dbTemplate = await _templateGroupService.UpdateTemplate(id, requestDto);

                if (dbTemplate == null)
                {
                    _logger.LogError($"Error on Api");
                    return NotFound();

                }//if

                return Ok(_mapper.Map<TemplateGroupDto>(dbTemplate));
            }//try
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }
         

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTemplateGroup(int id)
        {

            try
            {
                await _templateGroupService.DeleteTemplateGroup(id);

                return NoContent();
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på Api'et", ex);
            }//catch
        }
    }


}

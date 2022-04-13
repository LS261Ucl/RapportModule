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
        private readonly ILogger<TemplateGroupController> _logger;
        private readonly IMapper _mapper;

        public TemplateGroupController(IGenericRepository<TemplateGroup> templateGroupRepository, 
            ILogger<TemplateGroupController> logger,
            IMapper mapper)
        {
            _templateGroupRepository = templateGroupRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemplateGroupDto>>> GetTemplateGroups()
        {
            try
            {
                var dbTemplateGroup = await _templateGroupRepository.GetAllAsync();

                if(dbTemplateGroup == null)
                {
                    _logger.LogError("Kunne ikke finde Skabelon grupperne");
                    return NotFound();
                }

                return Ok(_mapper.Map<IReadOnlyList<TemplateGroupDto>>(dbTemplateGroup));
            }//try
            catch (Exception ex)
            {
                throw new Exception("Kunne ikke finde nogle grupper, fra Api'et", ex);
            }//catch

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateGroupDto>> GetTemplateGroup(int id)
        {
            try
            {
                var templateGroup = await _templateGroupRepository.GetAsync(x => x.Id == id);

                if (templateGroup == null)
                {
                    _logger.LogError($"Kunne ikke finde {nameof(TemplateGroup)} med følgende Id: {id}");
                    return NotFound();
                }

                return Ok(_mapper.Map<TemplateGroup>(templateGroup));
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
                var group = _mapper.Map<TemplateGroup>(requestDto);

                var request = await _templateGroupRepository.CreateAsync(group);
                
                if(request == null)
                {
                    _logger.LogError($"Kunne ikke få lov til at oprette følgende gruppe {nameof(TemplateGroup)}");
                    return BadRequest();
                }

                return Ok(_mapper.Map<TemplateGroup>(request));

            }//try
            catch (Exception ex)
            {
                throw new Exception("Api", ex);
            }//catch
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TemplateGroup>> UpdateTemplateGroup(int id,UpdateTemplateGroupDto requestDto)
        {

            try
            {
                var dbTemplateGroup = await _templateGroupRepository.GetAsync(x => x.Id == id);

                if (dbTemplateGroup == null)
                {
                    _logger.LogInformation($"Kunne ikke finde {nameof(TemplateGroup)} med følgnede Id : {id}");
                    return NotFound();
                }//if


                _mapper.Map(requestDto, dbTemplateGroup);

                var updated = await _templateGroupRepository.UpdateAsync(dbTemplateGroup);

                return Ok(_mapper.Map<TemplateGroup>(dbTemplateGroup));
            }//try
            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke finde gruppen med følgende id: {id}, fra Api'et", ex);
            }//catch
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

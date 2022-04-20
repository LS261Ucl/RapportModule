using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILogger<TemplateController> _logger;
        private readonly IMapper _mapper;

        public TemplateController(IGenericRepository<Template> templateRepository,
            ILogger<TemplateController> logger,
            IMapper mapper)
        {
            _templateRepository = templateRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<TemplateDto>>> GetTemplatesAsync()
        {
            try
            {
                var dbTemplate = await _templateRepository.GetAllAsync();

                if(dbTemplate == null)
                {
                    _logger.LogError("Kunne ikke finde skabelonerne, fejl på controlleren");
                    return NotFound();
                }

                var dto = _mapper.Map<List<TemplateDto>>(dbTemplate);

                return Ok(dto);
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente skabelonerne", ex);
            }//catch
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateDto>> GetTemplateByIdAsync(int id)
        {
            try
            {
                var dbTemplate = await _templateRepository.GetAsync(x => x.Id == id);

                if (dbTemplate == null)
                {
                    _logger.LogInformation($"Kunne ikke finde {nameof(Template)} med id: {id}");
                    return NotFound();
                }//if

                return Ok(_mapper.Map<Template>(dbTemplate));
            }//try
            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke finde skabelone med følgende id fra Api'et: {id}", ex);
            }//catch
        }

        [HttpGet("{id}/groups")]
        public async Task<ActionResult<TemplateDto>> GetTemplateWhitChildren(int id)
        {
            try
            {
                var dbTemplate = await _templateRepository.GetAsync(x => x.Id == id, x => x.Include(t => t.TemplateGroups).ThenInclude(g => g.Elements));
                if (dbTemplate != null)
                {
                    return _mapper.Map<TemplateDto>(dbTemplate);
                }
                return _mapper.Map<TemplateDto>(null);


            }//try
            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke finde Skabelon med følgende id {id}", ex);
            }//catch
        }


            [HttpPost]
        public async Task<ActionResult<Template>> CreateTemplate([FromBody] CreateTemplateDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Template>(requestDto);

                var dbTemplate = await _templateRepository.CreateAsync(dbRequest);

                if (dbTemplate == null)
                {
                    _logger.LogInformation($"Kunne ikke oprette {nameof(Template)}");
                    return BadRequest();
                }//if

                return Ok(_mapper.Map<TemplateDto>(dbTemplate));
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTemplateAsync(int id, UpdateTemplateDto requestDto)
        {
            try
            {
                var dbTemplate = await _templateRepository.GetAsync(x => x.Id == id);

                if (dbTemplate == null)
                {
                    _logger.LogInformation($"Kunne ikke finde {nameof(Template)} med følgende id : {id}");
                    return NotFound();
                }//if

                _mapper.Map(requestDto, dbTemplate);
                var dbRequest = await _templateRepository.UpdateAsync(dbTemplate);

                return Ok(_mapper.Map<TemplateDto>(dbTemplate));
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
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
                    _logger.LogInformation($"Kunne ikke få lov til at slette {nameof(Template)} med følgende id : {id}");
                    return NotFound();
                }//if

                return NoContent();
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på Api'et", ex);
            }//catch
        }

    }
}

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
        private readonly ITemplateService _templateService;
        private readonly ILogger<TemplateController> _logger;

        public TemplateController(ITemplateService templateService, 
            ILogger<TemplateController> logger)
        {
            _templateService = templateService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemplateDto>>> GetTemplatesAsync()
        {
            try
            {
                var dbTemplate = await _templateService.GetTemplates();

                if(dbTemplate == null)
                {
                    _logger.LogError("Kunne ikke finde skabelonerne, fejl på controlleren");
                    return NotFound();
                }

              

                return Ok(dbTemplate);
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
                var dbTemplate = await _templateService.GetTemplateById(id);

                if (dbTemplate == null)
                {
                    _logger.LogInformation($"Kunne ikke finde {nameof(Template)} med id: {id}");
                    return NotFound();
                }//if

                return Ok(dbTemplate);
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
                var dbTemplate = await _templateService.GetTemplateAndItsChilderen(id);
                if (dbTemplate != null)
                {
                    return Ok(dbTemplate);
                }
                else
                {
                    return NotFound();
                }
           


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
               

                var dbTemplate = await _templateService.CreateTemplate(requestDto);

                if (dbTemplate == null)
                {
                    _logger.LogInformation($"Kunne ikke oprette {nameof(Template)}");
                    return BadRequest();
                }//if

                return Ok(dbTemplate);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Template>> UpdateReportAsync(int id, TemplateDto requestDto)
        {
            try
            {
                if (id != null)
                {
                    await _templateService.UpdateTemplate(id, requestDto);

                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error on controller", ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTemplateAsync(int id)
        {
            try
            {
                await _templateService.DeleteTemplate(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Controller", ex);
            }
        }

    }
}

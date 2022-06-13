﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;

        public TemplateController(ITemplateService templateService,
            ILogger<TemplateController> logger,
            IMapper mapper)
        {
            _templateService = templateService;
            _logger = logger;
            _mapper = mapper;
        }

     //   [Authorize(Policy ="Admin")]
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
                var dbTemplate = await _templateService.GetTemplateById(id);

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
                var dbTemplate = await _templateService.GetTemplateAndItsChilderen(id);
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
        public async Task<ActionResult<TemplateDto>> CreateTemplate([FromBody] CreateTemplateDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Template>(requestDto);

                var dbTemplate = await _templateService.CreateTemplate(requestDto);

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
        public async Task<ActionResult> UpdateTemplateAsync(int id, TemplateDto requestDto)
        {
            try
            {
               var dbTemplate = await _templateService.UpdateTemplate(id, requestDto);

                if(dbTemplate == null)
                {
                    _logger.LogError($"Error on Api");
                    return NotFound();

                }

                return Ok(_mapper.Map<TemplateDto>(dbTemplate));
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTemplateAsync(int id)
        {

            try
            {
                 await _templateService.DeleteTemplate(id);

                return NoContent();
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på Api'et", ex);
            }//catch
        }

    }
}

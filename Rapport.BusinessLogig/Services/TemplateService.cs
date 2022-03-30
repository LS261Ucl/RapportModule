using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IGenericRepository<Template>? _templateRepository;
        private IMapper _mapper;

        public TemplateService(IGenericRepository<Template> templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<Template>> CreateTemplate( [FromBody]CreateTemplateDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Template>(requestDto);

                var dbTemplate = await _templateRepository.CreateAsync(dbRequest);
               

                return dbTemplate;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch


        }

        public Task<ActionResult> DeleteTemplate(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<TemplateDto>>> GetAllTemplate()
        {
            try
            {
                var dbTemplate = await _templateRepository.GetAllAsync();

                var request = _mapper.Map<List<TemplateDto>>(dbTemplate);

                return request;
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente skabelonerne", ex);
            }//catch
        }

        public Task<ActionResult<TemplateDto>> GetTemplateById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TemplateDto>> GetTemplateWhitChilderen(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> UpdateTemplate(int id, TemplateDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}

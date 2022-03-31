using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;

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

        //public async Task<ActionResult<List<TemplateDto>>> GetTemplate(int id)
        //{
        //    var dbTemplate = await _templateRepository.GetAsync(x => x.Id == id);
          
        //}

        public async Task<ActionResult<TemplateDto>> GetTemplateWhitChilderen(int id)
        {
            try
            {
                var dbTemplate = await _templateRepository.GetAsync(x => x.Id == id, x => x.Include(t => t.TemplateGroups).ThenInclude(g => g.Elements));
                return _mapper.Map<TemplateDto>(dbTemplate);
            }
            catch(Exception ex)
            {
                throw new Exception($"Kunne ikke finde Skabelon med følgende id {id}", ex);
            }
           
        }


        public async Task<ActionResult<Template>> UpdateTemplate(int id, TemplateDto requestDto)
        {
            try
            {
                var dbTemplate = await _templateRepository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, dbTemplate);

                var dbRequest = await _templateRepository.UpdateAsync(dbTemplate);

                return dbRequest;
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }
    }
}

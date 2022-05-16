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
        private readonly IGenericRepository<Template> _repository;
        private readonly IMapper _mapper;

        public TemplateService(IGenericRepository<Template> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Template> CreateTemplate([FromBody] CreateTemplateDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Template>(requestDto);

                var dbTemplate = await _repository.CreateAsync(dbRequest);

                return dbTemplate;
            }//try 
          
            catch (Exception ex)
            {
                throw new Exception("Fejl på TemplateService, Bussnieslogin", ex);
            }//catch
        }

        public async Task DeleteTemplate(int id)
        {
            try
            {
                bool delete = await _repository.DeleteAsync(id);
                
                       }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på TemplateService, Bussnieslogin", ex);
            }//catch
        }

        public async Task<TemplateDto> GetTemplateAndItsChilderen(int id)
        {
            try
            {
                var dbTemplate = await _repository.GetAsync(x => x.Id == id, x => x.Include(t => t.TemplateGroups).ThenInclude(g => g.Elements));
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

        public async Task<TemplateDto> GetTemplateById(int id)
        {
            try
            {
                var dbTemplate = await _repository.GetAsync(x => x.Id == id);
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

        public async Task<List<TemplateDto>> GetTemplates()
        {
            try
            {
                var dbTemplate = await _repository.GetAllAsync();

                    return _mapper.Map<List<TemplateDto>>(dbTemplate);
               



            }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på TemplateService, Bussnieslogin", ex);
            }//catch
        }

        public async Task<Template> UpdateTemplate(int id, TemplateDto requestDto)
        {
            try
            {
                var dbTemplate = await _repository.GetAsync(x => x.Id ==id);

                _mapper.Map(requestDto, dbTemplate);

                var updated = await _repository.UpdateAsync(dbTemplate);

                return updated;
            }
            
            catch(Exception ex)
            {
                throw new Exception("Error on Controller", ex);
            }
                
        }

    }
}

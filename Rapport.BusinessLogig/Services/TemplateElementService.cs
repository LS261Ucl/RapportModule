using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class TemplateElementService : ITemplateElementService
    {
        private readonly IGenericRepository<TemplateElement> _repository;
        private readonly IMapper _mapper;

        public TemplateElementService(IGenericRepository<TemplateElement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TemplateElement> CreateTemplateElement([FromBody] CreateTemplateElementDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<TemplateElement>(requestDto);

                var dbElement = await _repository.CreateAsync(dbRequest);

                return dbElement;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på TemplateService, Bussnieslogin", ex);
            }//catch
        }

        public Task DeleteTemplateElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TemplateElementDto>> GetTemplateElemens()
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateElementDto> GetTemplateElementById(int id)
        {
            try
            {
                var dbTemplate = await _repository.GetAsync(x => x.Id == id);
                if (dbTemplate != null)
                {
                    return _mapper.Map<TemplateElementDto>(dbTemplate);
                }
                return _mapper.Map<TemplateElementDto>(null);


            }//try
            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke finde Skabelon med følgende id {id}", ex);
            }//catch
        }
    }
}

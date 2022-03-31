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
        public TemplateElementService(IGenericRepository<TemplateElement> templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public IGenericRepository<TemplateElement> _templateRepository { get; }
        public IMapper _mapper { get; }

        public async Task<ActionResult<TemplateElement>> CreateTemplateElement([FromBody] CreateTemplateElementDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<TemplateElement>(requestDto);
                var templateElement = await _templateRepository.CreateAsync(dbRequest);    


                return templateElement;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch
        }

        public Task<ActionResult> DeleteTemplateElement(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<TemplateElementDto>>> GetTemplateElements()
        {
            try
            {
                var templateElements = await _templateRepository.GetAllAsync();

                var request = _mapper.Map<List<TemplateElementDto>>(templateElements);

                return request;
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente skabelonerne", ex);
            }//catch
        }

        public Task<ActionResult<TemplateElementDto>> GetTemplateElementById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<TemplateElement>> UpdateTemplateElement(int id, UpdateTemplateElementDto requestDto)
        {
            try
            {
                var templateElement = await _templateRepository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, templateElement);

                var dbRequest = await _templateRepository.UpdateAsync(templateElement);

                return dbRequest;
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }
    }
}

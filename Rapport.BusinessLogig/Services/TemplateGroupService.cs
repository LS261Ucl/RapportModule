using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.TemplateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class TemplateGroupService : ITemplateGroupService
    {

        public IGenericRepository<TemplateGroup>? _templateGroupRepository { get; }
        public IMapper _mapper { get; }


        public TemplateGroupService(IGenericRepository<TemplateGroup>? templateGroupRepository, IMapper mapper)
        {
           
            _templateGroupRepository = templateGroupRepository;
            _mapper = mapper;
        }


        public async Task<ActionResult<TemplateGroup>> CreateTemplateGroup([FromBody] CreateTemplateGroupDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<TemplateGroup>(requestDto);
                var templateGroup = await _templateGroupRepository.CreateAsync(dbRequest);


                return templateGroup;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch
        }

        public Task<ActionResult> DeleteTemplateGroup(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<TemplateGroupDto>>> GetTemplateGroups()
        {
            try
            {
                var templateGroups = await _templateGroupRepository.GetAllAsync();

                var request = _mapper.Map<List<TemplateGroupDto>>(templateGroups);

                return request;
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente skabelonerne", ex);
            }//catch
        }

        public Task<ActionResult<TemplateGroupDto>> GetTemplateGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TemplateGroupDto>> GetTemplateGroupWhitChild(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<TemplateGroup>> UpdateTemplateGroup(int id, UpdateTemplateGroupDto requestDto)
        {
            try
            {
                var templateGroup = await _templateGroupRepository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, templateGroup);

                var dbRequest = await _templateGroupRepository.UpdateAsync(templateGroup);

                return dbRequest;
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }
    }
}

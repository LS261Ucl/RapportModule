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
        private readonly IGenericRepository<TemplateGroup>? _templateGroupsRepository;
        private readonly IMapper? _mapper;

        public TemplateGroupService(IGenericRepository<TemplateGroup> templateGroupsRepository, IMapper mapper)
        {
            _templateGroupsRepository = templateGroupsRepository;
            _mapper = mapper;
        }

        public async Task<TemplateGroup> CreateTemplateGroup([FromBody] CreateTemplateGroupDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<TemplateGroup>(requestDto);

                var dbGroup = await _templateGroupsRepository.CreateAsync(dbRequest);

                return dbGroup;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på TemplateService, Bussnieslogin", ex);
            }//catch
        }

        public Task DeleteTemplateGroup(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateGroupDto> GetTemplateGroupById(int id)
        {
            try
            {
                var dbTemplate = await _templateGroupsRepository.GetAsync(x => x.Id == id);
                if (dbTemplate != null)
                {
                    return _mapper.Map<TemplateGroupDto>(dbTemplate);
                }
                return _mapper.Map<TemplateGroupDto>(null);


            }//try
            catch (Exception ex)
            {
                throw new Exception($"Kunne ikke finde Skabelon med følgende id {id}", ex);
            }//catch
        }

        public Task<List<TemplateGroupDto>> GetTemplategroups()
        {
            throw new NotImplementedException();
        }
    }
}

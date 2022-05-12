using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class ReportGroupService : IReportGroupService
    {
        private readonly IGenericRepository<ReportGroup>? _repository;
        private IMapper? _mapper;

        public ReportGroupService(IGenericRepository<ReportGroup> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReportGroup> CreateReportGroup([FromBody] CreateReportGroupDto requestDto)
        {
            try
            {

                var dbRequest = _mapper.Map<ReportGroup>(requestDto);

                var dbResult = await _repository.CreateAsync(dbRequest);


                return _mapper.Map<ReportGroup>(dbResult);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        public async Task DeleteReportGroup(int id)
        {
            try
            {
                bool delete = await _repository.DeleteAsync(id);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        public async Task<ReportGroupDto> GetReportGroupById(int id)
        {
            var group = await _repository.GetAsync(x => x.Id == id);
            return _mapper.Map<ReportGroupDto>(group);
        }

        public async Task<List<ReportGroupDto>> GetReportGroups()
        {
           var groups =  await _repository.GetAllAsync();

            return _mapper.Map<List<ReportGroupDto>>(groups);

        }

        public async Task<ReportGroup> UpdateReportGroup(int id, ReportGroupDto requestDto)
        {
            try
            {
                var dbReport = await _repository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, dbReport);

                var updated = await _repository.UpdateAsync(dbReport);

                return updated;


            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }
    }
}

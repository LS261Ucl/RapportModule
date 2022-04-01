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
        public IGenericRepository<ReportGroup> _reportGroupRepository { get; }
        public IMapper _mapper { get; }

        public ReportGroupService(IGenericRepository<ReportGroup> reportGroupRepository, IMapper mapper )
        {
            _reportGroupRepository = reportGroupRepository;
            _mapper = mapper;
        }

        
        public async Task<ActionResult<ReportGroup>> CreateReportGroup([FromBody] CreateReportGroupDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<ReportGroup>(requestDto);
                var reportGroup = await _reportGroupRepository.CreateAsync(dbRequest);

                return reportGroup;

            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch
        }

        public Task<ActionResult<List<ReportGroupDto>>> GetReportGroups()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<ReportGroupDto>> GetReportGroupById(int id)
        {
            try
            {
                var reportGroup = await _reportGroupRepository.GetAsync(x => x.Id == id);

                if (reportGroup != null)
                {
                    return _mapper.Map<ReportGroupDto>(reportGroup);
                }
                else
                {
                    return _mapper.Map<ReportGroupDto>(null);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Unable to find ReportGroup whit this id: {id}", ex);
            }
            
        }

        public async Task<ActionResult<ReportGroup>> UpdateReportGroup(int id, UpdateReportGroupDto requestDto)
        {
            try
            {
                var reportGroup = await _reportGroupRepository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, reportGroup);

                var dbRequest = await _reportGroupRepository.UpdateAsync(reportGroup);

                return dbRequest;
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende raport med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }

        public Task<ActionResult> DeleteReportGroup(int id)
        {
            throw new NotImplementedException();
        }
    }
}

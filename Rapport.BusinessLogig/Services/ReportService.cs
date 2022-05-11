using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepository<Report> _repository;
        private readonly IMapper _mapper;

        public ReportService(IGenericRepository<Report> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Report> CreateReport([FromBody] CreateReportDto requestDto)
        {
            try
            {

                var dbRequest = _mapper.Map<Report>(requestDto);

                var dbResult = await _repository.CreateAsync(dbRequest);


                return _mapper.Map<Report>(dbResult);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        public Task DeleteReport(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReportDto> GetReportAndItsChilderen(int id)
        {
            try
            {
                var dbReport = await _repository.GetAsync(x => x.Id == id, x => x.Include(r => r.ReportGroups).ThenInclude(g => g.Elements));

                return _mapper.Map<ReportDto>(dbReport);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        public Task<List<ReportDto>> GetReports()
        {
            throw new NotImplementedException();
        }

        public Task<ReportDto> GetReportyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

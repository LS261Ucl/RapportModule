using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IGenericRepository<ReportDto> _reportRepository { get; }
        public IMapper _mapper { get; }
        public ReportService(IGenericRepository<ReportDto> reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

      
        public async Task<ActionResult<Report>> CreateReport([FromBody] CreateReportDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Report>(requestDto);
                //var report = await _reportRepository.CreateAsync(dbRequest);

                return dbRequest;
        
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch
        }

        public Task<ActionResult> DeleteReport(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ReportDto>> GetReportById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<ReportDto>>> GetReports()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Report>> UpdateReport(int id, UpdateReportDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}

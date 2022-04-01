using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Report;

namespace Rapport.BusinessLogig.Services
{
    public class ReportService : IReportService
    {
        public IGenericRepository<Report> _reportRepository { get; }
        public IMapper _mapper { get; }
        public ReportService(IGenericRepository<Report> reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

      
        public async Task<ActionResult<Report>> CreateReport([FromBody] CreateReportDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Report>(requestDto);
                var report = await _reportRepository.CreateAsync(dbRequest);

                return report;
        
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

        public async Task<ActionResult<ReportDto>> GetReportById(int id)
        {
            try
            {
                var reports = await _reportRepository.GetAsync(x => x.Id == id);
                if (reports == null)
                {
                    return _mapper.Map<ReportDto>(reports);
                }

                else
                    return _mapper.Map<ReportDto>(null);
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente Rapporterne", ex);
            }//catch
        }

        public async Task<ActionResult<List<ReportDto>>> GetReports()
        {
            try
            {
                var reports = await _reportRepository.GetAllAsync();

                var request = _mapper.Map<List<ReportDto>>(reports);

                return request;
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente Rapporterne", ex);
            }//catch
        }

        public async Task<ActionResult<Report>> UpdateReport(int id, UpdateReportDto requestDto)
        {
            try
            {
                var report = await _reportRepository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, report);

                var dbRequest = await _reportRepository.UpdateAsync(report);

                return dbRequest;
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende raport med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }

        public async Task<ActionResult<ReportDto>> GetReportwhitchildren(int id)
        {
            try
            {
                var reports = await _reportRepository.GetAsync(x => x.Id == id, x => x.Include(r => r.ReportGroups).ThenInclude(g => g.Elements));
               
                if (reports == null)
                {
                    return _mapper.Map<ReportDto>(reports);
                }

                else
                    return _mapper.Map<ReportDto>(null);
            }//try
            catch (Exception ex)
            {
                throw new Exception( $"fik ikke lov til at hente Rapporten med følgende id: {id}", ex);
            }//catch
        }
    }
}

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

        public async Task DeleteReport(int id)
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

        public async Task<List<ReportDto>> GetReports()
        {
            try
            {
                var report = await _repository.GetAllAsync();

                return _mapper.Map<List<ReportDto>>(report);
            }
            catch(Exception ex)
            {
                throw new Exception("Error on service, businesslogig", ex);
            }

        }

 
        public async Task<ReportDto> GetReportyId(int id)
        {
            try
            {
                var report = await _repository.GetAsync(x => x.Id == id);

                return _mapper.Map<ReportDto>(report);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        public async Task<ReportDto> SearchReportBySearchText(int id, string searchText)
        {
            try
            {
                var report = new ReportDto();
                if(report.Id == id)
                {
                    await _repository.GetAsync(x => x.Equals(searchText));
                }
                if(report.Title == searchText)
                {
                    await _repository.GetAllAsync(x => x.Title == searchText);
                }

                return report;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Report> UpdateReport(int id, ReportDto requestDto)
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

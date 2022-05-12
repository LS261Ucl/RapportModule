using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.BusinessLogig.Services
{
    public class ReportElementService : IReportElementService
    {
        private readonly IGenericRepository<ReportElement> _repository;
        private readonly IMapper _mapper;

        public ReportElementService(IGenericRepository<ReportElement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReportElement> CreateReportElement([FromBody] CreateReportElementDto requestDto)
        {
            try
            {

                var dbRequest = _mapper.Map<ReportElement>(requestDto);

                var dbResult = await _repository.CreateAsync(dbRequest);


                return _mapper.Map<ReportElement>(dbResult);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        public async Task DeleteReportElement(int id)
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

        public async Task<ReportElementDto> GetReportElementById(int id)
        {
            try
            {
                var report = await _repository.GetAsync(x => x.Id == id);

                return _mapper.Map<ReportElementDto>(report);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        public async Task<ReportElement> UpdateReport(int id, ReportElementDto requestDto)
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
            }//catchthrow new NotImplementedException();
        }
    }
}

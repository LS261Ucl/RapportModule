using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Entites.RequestFeatures;
using Rapport.Shared.Dto_er.Report;
using Rapport.Shared.Paging;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportController> _logger;
        private readonly IMapper _mapper;


        public ReportController(
            IReportService reportService,
            ILogger<ReportController> logger,
            IMapper mapper)
        {
            _reportService = reportService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDto>>> GetReportsAsync()
        {
            try
            {
                var reports = await _reportService.GetReports();

                if (reports == null)
                {
                    _logger.LogError("Unable to find Templates");
                    return NotFound();
                }//if

                return Ok(reports);
            }//if
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//cathc
        }


        [HttpGet("{id}/groups")]
        public async Task<ActionResult<ReportDto>> GetReportWhitChildrenAscyn(int id)
        {
            try
            {
                var dbReport = await _reportService.GetReportAndItsChilderen(id);

                if (dbReport == null)
                {
                    _logger.LogInformation($"No {nameof(Report)} was found with this id : {id}");
                    return NotFound();
                }

                return Ok(_mapper.Map<ReportDto>(dbReport));

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Report>> CreateReportAsync([FromBody] CreateReportDto requestDto)
        {
            try
            {
               
                var dbRequest = _mapper.Map<Report>(requestDto);

                var dbResult = await _reportService.CreateReport(requestDto);


                return Ok(_mapper.Map<Report>(dbResult));

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Report>> UpdateReportAsync(int id, ReportDto requestDto)
        {
            try
            {
                var dbReport = await _reportService.UpdateReport(id, requestDto);

                if (dbReport == null)
                {
                    _logger.LogError($"Error on Api");
                    return NotFound();

                }//if

                return Ok(_mapper.Map<ReportDto>(dbReport));
            }//try
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende skabelon med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteReportAsync(int id)
        {

            try
            {
                await _reportService.DeleteReport(id);

                return NoContent();
            }//try
            catch (Exception ex)
            {
                throw new Exception("Fejl på Api'et", ex);
            }//catch
        }
    }


}

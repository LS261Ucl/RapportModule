using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Report;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IGenericRepository<Report> _reportGenericRepository;
        private readonly ILogger<ReportController> _logger;
        private readonly IGenericRepository<Report> reportRepository;
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IGenericRepository<Report> reportRepository,
            IReportService reportService,
            ILogger<ReportController> logger,
            IMapper mapper)
        {
            this.reportRepository = reportRepository;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetReportByIdAsync(int id)
        {
            try
            {
               var report = await _reportService.GetReportById(id);
                if (report == null)
                {
                    _logger.LogError($"Unable to find {nameof(Report)} whit this id: {id}");
                    return NotFound();
                }//if

                return Ok(_mapper.Map<Report>(report));
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpGet("{id}/groups")]
        public async Task<ActionResult<ReportDto>> GetReportWhitChildrenAscyn(int id)
        {
            try
            {
                var report = await _reportService.GetReportwhitchildren(id);

                if (report== null)
                {
                    _logger.LogError($"Unable to find {nameof(Report)} whit this id: {id}");
                    return NotFound();
                }//if

                return Ok(report);

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
                var report = await _reportService.CreateReport(requestDto);

                if (report == null)
                {
                    _logger.LogError("Unable to create report");
                    return BadRequest();
                }//if

                return Ok(report);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Report>> UpdateReportAsync(int id, UpdateReportDto requestDto)
        {
            try
            {
                var report = await _reportService.UpdateReport(id, requestDto);

                if (report == null)
                {
                    _logger.LogError($"Unable to update {nameof(Report)} whit this id: {id}");
                    return BadRequest();
                }//if

                return Ok(report);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteReportAsync(int id)
        {

            try
            {
                bool delete = await _reportGenericRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(Report)} whit this id : {id}");
                    return NotFound();
                }//if

                return NoContent();
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }
    }


}

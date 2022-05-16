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
        private readonly IReportService _reportService;
        private readonly IGenericRepository<Template> _templatGenericRepository;
        private readonly ILogger<ReportController> _logger;
        private readonly IGenericRepository<Report>? _reportRepository;
        public ReportController(IGenericRepository<Report> reportRepository,
            IReportService reportService,
            IGenericRepository<Template> templatGenericRepository,
            ILogger<ReportController> logger
          )
        {
            _reportRepository = reportRepository;
            _reportService = reportService;
            _templatGenericRepository = templatGenericRepository;
            _logger = logger;
   
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
                var report = await _reportService.GetReportyId(id);

                if (report == null)
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

                return Ok(dbReport);

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

                var dbResult = await _reportService.CreateReport(requestDto);


                return Ok(dbResult);

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
                if(id != null)
                {
                    await _reportService.UpdateReport(id, requestDto);

                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Error on controller", ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReportAsync(int id)
        {
            try
            {
                await _reportService.DeleteReport(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                throw new Exception("Error on Controller", ex);
            }
        }

    }


}

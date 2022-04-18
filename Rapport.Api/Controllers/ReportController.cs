using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<Template> _templatGenericRepository;
        private readonly ILogger<ReportController> _logger;
        private readonly IGenericRepository<Report> _reportRepository;
        private readonly IMapper _mapper;

        public ReportController(IGenericRepository<Report> reportRepository,
            IGenericRepository<Template> templatGenericRepository,
            ILogger<ReportController> logger,
            IMapper mapper)
        {
            _reportRepository = reportRepository;
            _templatGenericRepository = templatGenericRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDto>>> GetReportsAsync()
        {
            try
            {
                var reports = await _reportGenericRepository.GetAllAsync();

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
                var report = await _reportGenericRepository.GetAsync(x => x.Id == id);

                if (report == null)
                {
                    _logger.LogError($"Unable to find {nameof(Report)} whit this id: {id}");
                    return NotFound();
                }//if

                return Ok(_mapper.Map<ReportDto>(report));
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
                var dbReport = await _reportRepository.GetAsync(x => x.Id == id, x => x.Include(r => r.ReportGroups).ThenInclude(g => g.Elements));

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
                //var dbTemplate = await _templatGenericRepository.GetAsync(x => x.Id == id);

                //var dbGroup = new CreateReportDto
                //{
                //    TemplateId = dbTemplate.Id,
                //    Title = dbTemplate.Titel,                    
                //    RentalPeriodStart = DateTime.UtcNow

                //};

                //dbGroup = requestDto;

                var dbRequest = _mapper.Map<Report>(requestDto);

                var dbResult = await _reportRepository.CreateAsync(dbRequest);


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
                var dbReport = await _reportRepository.GetAsync(x => x.Id == id);

                if (dbReport == null)
                {
                    _logger.LogInformation($"No {nameof(Report)} was found whit this id: {id}");
                    return NotFound();
                }//if

                _mapper.Map(requestDto, dbReport);

                var updated = await _reportRepository.UpdateAsync(dbReport);

                return Ok(_mapper.Map<ReportDto>(dbReport));

            
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

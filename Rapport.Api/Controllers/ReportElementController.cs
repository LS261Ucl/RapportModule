using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportElementController : ControllerBase
    {
        private readonly IGenericRepository<ReportElement> _reportElementRepository;
        private readonly ILogger<ReportElementController> _logger;
        private readonly IReportElementService _reportElementService;
        private readonly IMapper _mapper;

        public ReportElementController(IGenericRepository<ReportElement> reportElementRepository, 
            IReportElementService reportElementService,
            ILogger<ReportElementController> logger,
            IMapper mapper)
        {
            _reportElementRepository = reportElementRepository;
            _reportElementService = reportElementService;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ReportElementDto>>> GetReportElements()
        {
            try
            {
                var reportElements = await _reportElementService.GetReportElements();


                if (reportElements == null)
                {
                    _logger.LogError("Unable to get TemplateElements");
                    return NotFound();
                }

                return Ok(reportElements);
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api");
            }
            

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportElementDto>> GetReportElement(int id)
        {
            try
            {
                var reportElement = await _reportElementService.GetReportElementById(id);

                if (reportElement == null)
                {
                    _logger.LogError($"Unable to find {nameof(ReportElement)} whit this id: {id}");
                    return NotFound();
                }

                return Ok(reportElement);
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }

        }

        [HttpPost]
        public async Task<ActionResult<ReportElement>> CreateReportElement([FromBody] CreateReportElementDto requestDto)
        {
            try
            {
                if (requestDto == null)
                {
                    return BadRequest();
                }
                else
                {
                    var reportElement = await _reportElementService.CreateReportElement(requestDto);

                    return Ok(reportElement);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReportElement>> UpdateReportElement(int id, UpdateReportElementDto requestDto)
        {
            try
            {
                var reportElement = await _reportElementService.UpdateReportElement(id, requestDto);

                if (reportElement == null)
                {
                    _logger.LogError($"Unable to find {nameof(ReportElement)} whit this id: {id}");
                    return BadRequest();
                }

                return Ok(requestDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReportElement(int id)
        {

            try
            {
                bool delete = await _reportElementRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(ReportElement)} whit this id : {id}");
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

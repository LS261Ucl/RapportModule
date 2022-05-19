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
        private readonly IReportElementService _reportElementService;
        private readonly ILogger<ReportElementController> _logger;
        private readonly IMapper _mapper;

        public ReportElementController(
            IReportElementService reportElementService,
            ILogger<ReportElementController> logger,
            IMapper mapper)
        {
            
            _logger = logger;
            _reportElementService = reportElementService;
            _mapper = mapper;
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
              //  var dbRequest = _mapper.Map<ReportElement>(requestDto);

                var dbResult = await _reportElementService.CreateReportElement(requestDto);

                if (dbResult == null)
                {
                    _logger.LogInformation($"Unable to create ReportField");
                    return BadRequest();
                }//if

                return Ok(_mapper.Map<ReportElement>(dbResult));
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }

        }
    }
}

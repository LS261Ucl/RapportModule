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
        private readonly IGenericRepository<ReportElement> _reportElementRepository;
        private readonly ILogger<ReportElementController> _logger;
        private readonly IMapper _mapper;

        public ReportElementController(IGenericRepository<ReportElement> reportElementRepository, 
            IReportElementService reportElementService,
            ILogger<ReportElementController> logger,
            IMapper mapper)
        {
            _reportElementRepository = reportElementRepository;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ReportElementDto>>> GetReportElements()
        {
            try
            {
                var reportElements = await _reportElementRepository.GetAllAsync();


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

        [HttpPut("{id}")]
        public async Task<ActionResult<ReportElement>> UpdateReportElement(int id, ReportElementDto requestDto)
        {
            try
            {
                var dbElement = await _reportElementRepository.GetAsync(x => x.Id == id);

                if (dbElement == null)
                {
                    _logger.LogInformation($"Unable to finde ReportField whit this id: {id}");
                    return NotFound();
                }//if

                _mapper.Map(requestDto, dbElement);

                var updated = await _reportElementRepository.UpdateAsync(dbElement);

                return Ok(_mapper.Map<ReportElement>(dbElement));
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

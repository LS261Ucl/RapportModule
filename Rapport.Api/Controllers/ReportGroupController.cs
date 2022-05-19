using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportGroupController : ControllerBase
    {
        private readonly IReportGroupService _reportGroupService;
        private readonly ILogger<ReportGroupController> _logger;
        private readonly IMapper _mapper;

        public ReportGroupController(
            IReportGroupService reportGroupService,
            IMapper mapper,
            ILogger<ReportGroupController> logger)
        {
            _reportGroupService = reportGroupService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<List<ReportGroupDto>>> GetReportGroups()
        {
            var reportGroups = await _reportGroupService.GetReportGroups();


            if (reportGroups == null)
            {
                _logger.LogError("Unable to get ReportGroups");
                return NotFound();
            }

            return Ok(reportGroups);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportGroupDto>> GetReportGroup(int id)
        {
            try
            {
                var reportGroup = await _reportGroupService.GetReportGroupById(id);

                if (reportGroup == null)
                {
                    _logger.LogError($"Unable to find {nameof(ReportGroup)} whit this id: {id}");
                    return NotFound();
                }

                return Ok(reportGroup);
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }
           
        }

        [HttpPost]
        public async Task<ActionResult<ReportGroup>> CreateReportGroup([FromBody] CreateReportGroupDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<ReportGroup>(requestDto);

                var dbResult = await _reportGroupService.CreateReportGroup(requestDto);
                if (dbResult == null)
                {
                    _logger.LogInformation("Unable to create ReportGroup in Api");
                    return BadRequest();
                }

                return Ok(_mapper.Map<ReportGroup>(dbResult));
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }
           
        } 

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IGenericRepository<ReportGroup> _reportGroupRepository;
        private readonly ILogger<ReportGroupController> _logger;
        private readonly IMapper _mapper;
        private readonly IReportGroupService _reportGroupService;

        public ReportGroupController(IReportGroupService reportGroupService,
            IGenericRepository<ReportGroup> reportGroupRepository,
            IMapper mapper,
            ILogger<ReportGroupController> logger)
        {
            _reportGroupService = reportGroupService;
            _reportGroupRepository = reportGroupRepository;
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
                if (requestDto == null)
                {
                    return BadRequest();
                }
                else
                {
                    var reportGroup = await _reportGroupService.CreateReportGroup(requestDto);

                    return Ok(reportGroup);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReportGroup>> UpdateReportGroup(int id, UpdateReportGroupDto requestDto)
        {
            try
            {
                var reportGroup = await _reportGroupService.UpdateReportGroup(id, requestDto);

                if (reportGroup == null)
                {
                    _logger.LogError($"Unable to find {nameof(ReportGroup)} whit this id: {id}");
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
        public async Task<ActionResult> DeleteReportGroup(int id)
        {

            try
            {
                bool delete = await _reportGroupRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(ReportGroup)} whit this id : {id}");
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

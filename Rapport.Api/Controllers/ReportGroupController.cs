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
        private readonly IGenericRepository<ReportGroup> _reportGroupRepository;
        private readonly IReportGroupService _reportGroupService;
        private readonly ILogger<ReportGroupController> _logger;
        private readonly IMapper _mapper;

        public ReportGroupController(
            IGenericRepository<ReportGroup> reportGroupRepository,
            IReportGroupService reportGroupService,
            IMapper mapper,
            ILogger<ReportGroupController> logger)
        {
            _reportGroupRepository = reportGroupRepository;
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

        [HttpPost("{id}")]
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReportGroup(int id, ReportGroupDto requestDto)
        {
            try
            {
                var dbGroup = await _reportGroupRepository.GetAsync(x => x.Id == id);

                if (dbGroup == null)
                {
                    _logger.LogInformation($"No {nameof(ReportGroup)} was found whit this id: {id}");
                    return NotFound();
                }

                _mapper.Map(requestDto, dbGroup);

                var updated = await _reportGroupRepository.UpdateAsync(dbGroup);

                if (updated == null)
                {
                    _logger.LogError($"Unable to Update ReportGroup whit this id: {id}");
                    return BadRequest();
                }

                return Ok(_mapper.Map<ReportGroup>(dbGroup));
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

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Employee;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IGenericRepository<Employee> employeeRepository,
            IEmployeeService employeeService, 
            ILogger<EmployeeController> logger,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    _logger.LogError($"Unable to find {nameof(Employee)} whit this id: {id}");
                    return NotFound();
                }//if

                return Ok(_mapper.Map<Employee>(employee));
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployeeAsync([FromBody] CreateEmployeeDto requestDto)
        {
            try
            {
                var employee = await _employeeService.CreateEmployee(requestDto);

                if (employee == null)
                {
                    _logger.LogError("Unable to create employee");
                    return BadRequest();
                }//if

                return Ok(employee);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, UpdateEmployeeDto requestDto)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployee(id, requestDto);

                if (employee == null)
                {
                    _logger.LogError($"Unable to update {nameof(Employee)} whit this id: {id}");
                    return BadRequest();
                }//if

                return Ok(employee);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {

            try
            {
                bool delete = await _employeeRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(Employee)} whit this id : {id}");
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

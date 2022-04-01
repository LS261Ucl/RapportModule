using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Customer;

namespace Rapport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(IGenericRepository<Customer> customerRepository,
            ILogger<CustomerController> logger,
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    _logger.LogError($"Unable to find {nameof(Customer)} whit this id: {id}");
                    return NotFound();
                }//if

                return Ok(_mapper.Map<Customer>(customer));
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomerAsync([FromBody] CreateCustomerDto requestDto)
        {
            try
            {
                var customer = await _customerService.CreateCustomer(requestDto);

                if (customer == null)
                {
                    _logger.LogError("Unable to create customer");
                    return BadRequest();
                }//if

                return Ok(customer);

            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomerAsync(int id, UpdateCustomerDto requestDto)
        {
            try
            {
                var customer = await _customerService.UpdateCustomer(id, requestDto);

                if (customer == null)
                {
                    _logger.LogError($"Unable to update {nameof(Customer)} whit this id: {id}");
                    return BadRequest();
                }//if

                return Ok(customer);
            }//try
            catch (Exception ex)
            {
                throw new Exception("Error on Api", ex);
            }//catch
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {

            try
            {
                bool delete = await _customerRepository.DeleteAsync(id);

                if (!delete)
                {
                    _logger.LogInformation($"Unable to find or delete {nameof(Customer)} whit this id : {id}");
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

using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Customer;


namespace Rapport.BusinessLogig.Interfaces
{
    public interface ICustomerService
    {
        Task<ActionResult<List<CustomerDto>>> GetCustomers();
        Task<ActionResult<CustomerDto>> GetCustomerById(int id);
        Task<ActionResult<Customer>> CreateCustomer([FromBody] CreateCustomerDto requestDto);
        Task<ActionResult<Customer>> UpdateCustomer(int id, UpdateCustomerDto requestDto);
        Task<ActionResult> DeleteCustomer(int id);
    }
}

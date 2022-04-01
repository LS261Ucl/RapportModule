using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CreateCustomerDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Customer>(requestDto);
                var customer = await _customerRepository.CreateAsync(dbRequest);

                return customer;

            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette kunde, fra Api'et", ex);
            }//catch
        }

        public  Task<ActionResult> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {

            try
            {
                var customer = await _customerRepository.GetAsync(x => x.Id == id);
                if (customer == null)
                {
                    return _mapper.Map<CustomerDto>(customer);
                }

                else
                    return _mapper.Map<CustomerDto>(null);
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente Rapporterne", ex);
            }//catch
        }

        public Task<ActionResult<List<CustomerDto>>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Customer>> UpdateCustomer(int id, UpdateCustomerDto requestDto)
        {
            try
            {
                var customer = await _customerRepository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, customer);

                var dbRequest = await _customerRepository.UpdateAsync(customer);

                return dbRequest;
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende Kunde med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] CreateEmployeeDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<Employee>(requestDto);
                var employee = await _employeeRepository.CreateAsync(dbRequest);

                return employee;

            }//try
            catch (Exception ex)
            {
                throw new Exception("Fik ikke lov til at oprette skabelon, fra Api'et", ex);
            }//catch
        }

        public Task<ActionResult> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            try
            {
                var reports = await _employeeRepository.GetAsync(x => x.Id == id);
                if (reports == null)
                {
                    return _mapper.Map<EmployeeDto>(reports);
                }

                else
                    return _mapper.Map<EmployeeDto>(null);
            }//try
            catch (Exception ex)
            {
                throw new Exception("fik ikke lov til at hente Rapporterne", ex);
            }//catch
        }

        public Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Employee>> UpdateEmployee(int id, UpdateEmployeeDto requestDto)
        {
            try
            {
                var employee = await _employeeRepository.GetAsync(x => x.Id == id);

                _mapper.Map(requestDto, employee);

                var dbRequest = await _employeeRepository.UpdateAsync(employee);

                return dbRequest;
            }//if
            catch (Exception ex)
            {
                throw new Exception($"kunne enten ikke finde følgende medarbejder med id: {id}, eller fik ikke lov til at opdatere den, fra Api'et", ex);
            }//catch
        }
    }
}

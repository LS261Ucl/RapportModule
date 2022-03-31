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
        public Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}

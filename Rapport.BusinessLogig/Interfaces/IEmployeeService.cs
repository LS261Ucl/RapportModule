using Microsoft.AspNetCore.Mvc;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Employee;

namespace Rapport.BusinessLogig.Interfaces
{
    public interface IEmployeeService
    {
        Task<ActionResult<List<EmployeeDto>>> GetEmployees();
        Task<ActionResult<EmployeeDto>> GetEmployeeById(int id);
        Task<ActionResult<Employee>> CreateEmployee([FromBody] CreateEmployeeDto requestDto);
        Task<ActionResult<Employee>> UpdateEmployee(int id, UpdateEmployeeDto requestDto);
        Task<ActionResult> DeleteEmployee(int id);
    }
}

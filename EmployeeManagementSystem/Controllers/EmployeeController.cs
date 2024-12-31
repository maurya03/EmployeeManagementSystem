using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService employeeService)
        {
            _service = employeeService;
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _service.GetAllEmployees();
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            ValidateEmployeeId(id);
            return await _service.GetEmployeeById(id);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<bool> AddEmployee(Employee employee)
        {
            ValidateEmployee(employee);
            return await _service.AddEmployee(employee);
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            ValidateEmployee(employee);
            ValidateEmployeeId(id);
            return await _service.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<bool> DeleteEmployee(int id)
        {
            ValidateEmployeeId(id);
            return await _service.DeleteEmployee(id);
        }

        private void ValidateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ValidationException($"{nameof(Employee)} not found.");
            }
            else if (String.IsNullOrEmpty(employee.Name))
            {
                throw new ValidationException("Employee name is null or empty");
            }
            else if (String.IsNullOrEmpty(employee.Email))
            {
                throw new ValidationException("Email is Null or empty");
            }
            else if (String.IsNullOrEmpty(employee.Department))
            {
                throw new ValidationException("Department is Null or empty");
            }
        }
        private void ValidateEmployeeId(int id)
        {
            if (id >= 0)
            {
                throw new ValidationException("Employee id should be greater than 0.");
            }
        }
    }
}

using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementSystem.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            ValidateEmployee(employee);
            return await _repository.AddEmployeeAsync(employee) > 0;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            ValidateEmployeeId(id);
            return await _repository.DeleteEmployeeAsync(id) > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _repository.GetEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            ValidateEmployeeId(id);
            return await _repository.GetEmployeeByIdAsync(id);
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            ValidateEmployee(employee);
            return await _repository.UpdateEmployeeAsync(employee) > 0;
        }

        private void ValidateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException($"{nameof(Employee)} not found.");
            }
            else if (String.IsNullOrEmpty(employee.Name))
            {
                throw new ArgumentNullException("Employee name is null or empty");
            }
            else if (String.IsNullOrEmpty(employee.Email))
            {
                throw new ArgumentNullException("Email is Null or empty");
            }
            else if (String.IsNullOrEmpty(employee.Department))
            {
                throw new ArgumentNullException("Department is Null or empty");
            }
        }

        private void ValidateEmployeeId(int id)
        {
            if (id >= 0)
            {
                throw new ArgumentOutOfRangeException("Employee id should be greater than 0.");
            }
        }
    }
}

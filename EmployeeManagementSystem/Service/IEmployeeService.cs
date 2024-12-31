using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}

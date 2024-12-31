using EmployeeManagementSystem.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            var parameters = new[]
            {
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Department", employee.Department),
                new SqlParameter("@Email",employee.Email)
            };
            return await _context.Database.ExecuteSqlRawAsync("EXEC AddEmployee @Name, @Department, @Email", parameters);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var param = new SqlParameter("@Id", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmployee @Id", param);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var param = new SqlParameter("@Id", id);
            return await _context.Employees.FromSqlRaw("EXEC GetEmployeeById @Id", param).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.FromSqlRaw("EXEC GetAllEmployees").ToListAsync();
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            var parameters = new[]
            {
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Department", employee.Department),
                new SqlParameter("@Email", employee.Email)
            };
            return await _context.Database.ExecuteSqlRawAsync("EXEC AddEmployee @Name, @Department, @Email", parameters);
        }
    }
}

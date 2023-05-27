using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Data;
using OnionArchitecture.Domain.Models;

namespace OnionArchitecture.Repositry.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result=await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var result=await _applicationDbContext.Employees.FirstOrDefaultAsync(e =>e.Id==employeeId);
            if (result != null) 
            {
                _applicationDbContext.Employees.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _applicationDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
           return await _applicationDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _applicationDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if(result != null)
            {
                result.Name=employee.Name;
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

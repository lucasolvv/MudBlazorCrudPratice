using MUDCRUD.Components.Domain;
using MUDCRUD.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace MUDCRUD.Components.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Contracts.EmployeeContract>> GetAllEmployeesAsync()
        {
            return await
                _context.Employees.Select(e => new Contracts.EmployeeContract
                {
                    Id = e.Id,
                    EmployeeName = e.EmployeeName,
                    Gender = e.Gender,
                    City = e.City,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt
                }).ToListAsync();
        }
        public async Task<Contracts.EmployeeContract> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found.");
            return new Contracts.EmployeeContract
            {
                Id = employee.Id,
                EmployeeName = employee.EmployeeName,
                Gender = employee.Gender,
                City = employee.City,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
        public async Task CreateEmployeeAsync(Contracts.CreateEmployeeContract contract)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                EmployeeName = contract.EmployeeName,
                City = contract.City,
                Gender = contract.Gender,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
               _context.Employees.Add(employee);
               await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Contracts.UpdateEmployeeContract contract)
        {
            var employee = await _context.Employees.FindAsync(contract.Id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found.");
            employee.EmployeeName = contract.EmployeeName;
            employee.City = contract.City;
            employee.Gender = contract.Gender;
            employee.UpdatedAt = DateTime.UtcNow;

        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found.");
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}

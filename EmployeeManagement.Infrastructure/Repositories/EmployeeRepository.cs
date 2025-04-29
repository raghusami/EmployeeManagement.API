using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();
        public async Task<Employee> GetByIdAsync(Guid id) => await _context.Employees.FindAsync(id);
        public async Task AddAsync(Employee employee) { _context.Employees.Add(employee); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Employee employee) { _context.Employees.Update(employee); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(Employee employee) { _context.Employees.Remove(employee); await _context.SaveChangesAsync(); }
    }
}

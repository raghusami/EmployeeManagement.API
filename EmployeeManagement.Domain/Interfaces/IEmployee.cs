using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IEmployee
    {
        public  Task<List<Employee>> GetAllAsync();
        public  Task<Employee> GetByIdAsync(Guid id);
        public  Task AddAsync(Employee employee);
        public  Task UpdateAsync(Employee employee);
        public  Task DeleteAsync(Employee employee);
    }
}

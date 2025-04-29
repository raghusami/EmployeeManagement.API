using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Employees.Commands
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IGenericRepository<Employee> _repository;

        public UpdateEmployeeHandler(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);
            if (employee == null) return false;

            employee.UpdateEmployee(request.Name, request.Department, request.Email, request.Phone, request.Salary);
            await _repository.UpdateAsync(employee);
            return true;
        }
    }
}

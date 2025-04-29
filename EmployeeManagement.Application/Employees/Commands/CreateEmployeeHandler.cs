using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Employees.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IGenericRepository<Employee> _repository;

        public CreateEmployeeHandler(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(request.Name, request.Department, request.Email, request.Phone, request.Salary);
            await _repository.AddAsync(employee);
            return employee.Id;
        }
    }
}

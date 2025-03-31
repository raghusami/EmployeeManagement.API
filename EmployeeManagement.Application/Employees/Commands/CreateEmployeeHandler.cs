using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using MediatR;

namespace EmployeeManagement.Application.Employees.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly EmployeeRepository _repository;

        public CreateEmployeeHandler(EmployeeRepository repository)
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

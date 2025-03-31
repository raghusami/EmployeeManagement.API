using EmployeeManagement.Infrastructure.Repositories;
using MediatR;

namespace EmployeeManagement.Application.Employees.Commands
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly EmployeeRepository _repository;

        public UpdateEmployeeHandler(EmployeeRepository repository)
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

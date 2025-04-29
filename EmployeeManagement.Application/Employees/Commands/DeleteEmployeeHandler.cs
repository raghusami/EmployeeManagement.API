using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Employees.Commands
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IGenericRepository<Employee> _repository;

        public DeleteEmployeeHandler(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);
            if (employee == null) return false;

            await _repository.DeleteAsync(employee);
            return true;
        }
    }
}

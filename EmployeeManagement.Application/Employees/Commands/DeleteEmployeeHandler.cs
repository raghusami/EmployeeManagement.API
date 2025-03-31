using EmployeeManagement.Infrastructure.Repositories;
using MediatR;

namespace EmployeeManagement.Application.Employees.Commands
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly EmployeeRepository _repository;

        public DeleteEmployeeHandler(EmployeeRepository repository)
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

using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Employees.Queries
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly EmployeeRepository _repository;

        public GetEmployeeByIdHandler(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}

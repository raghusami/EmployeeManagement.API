using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using MediatR;

namespace EmployeeManagement.Application.Employees.Queries
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<Employee>>
    {
        private readonly EmployeeRepository _repository;

        public GetEmployeesHandler(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

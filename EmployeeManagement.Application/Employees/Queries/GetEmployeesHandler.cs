using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Employees.Queries
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<Employee>>
    {
        private readonly IGenericRepository<Employee> _repository;

        public GetEmployeesHandler(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

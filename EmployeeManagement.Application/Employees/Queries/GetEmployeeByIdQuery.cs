using EmployeeManagement.Domain.Entities;
using MediatR;

namespace EmployeeManagement.Application.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }
    }
}

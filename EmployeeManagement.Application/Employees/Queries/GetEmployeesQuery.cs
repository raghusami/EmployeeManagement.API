using MediatR;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Employees.Queries
{
    public class GetEmployeesQuery :IRequest<List<Employee>>
    {

    }
}

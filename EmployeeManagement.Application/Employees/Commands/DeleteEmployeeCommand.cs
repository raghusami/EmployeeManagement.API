using MediatR;

namespace EmployeeManagement.Application.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

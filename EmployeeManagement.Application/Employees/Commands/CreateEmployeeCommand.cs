﻿using MediatR;


namespace EmployeeManagement.Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}

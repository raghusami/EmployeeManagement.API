using EmployeeManagement.Application.Employees.Commands;
using FluentValidation;

namespace EmployeeManagement.API.Validator
{
    public class EmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Employee name must not be empty")
             .MaximumLength(100).WithMessage("Employee name must not exceed 100 characters");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Department must not be empty");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than zero");
        }
    }
}

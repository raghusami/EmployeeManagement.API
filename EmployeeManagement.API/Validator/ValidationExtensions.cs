using EmployeeManagement.Application.Employees.Commands;
using FluentValidation;

namespace EmployeeManagement.API.Validator
{
    public static class ValidationExtensions 
    {
        public static IServiceCollection RegisterValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateEmployeeCommand>,EmployeeValidator>();
            return services;
        }
    }
}

using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Repositories;

namespace EmployeeManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddScoped<IEmployee,EmployeeRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeManagement.Application.Employees.Commands.CreateEmployeeCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeManagement.Application.Employees.Commands.UpdateEmployeeCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeManagement.Application.Employees.Commands.DeleteEmployeeCommand).Assembly));
            return services;
        }
    }
}

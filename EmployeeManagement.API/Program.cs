using EmployeeManagement.Infrastructure.Repositories;
using EmployeeManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();


// ✅ Register MediatR and specify the assembly where handlers are located
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeManagement.Application.Employees.Commands.CreateEmployeeCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeManagement.Application.Employees.Commands.UpdateEmployeeCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeManagement.Application.Employees.Commands.DeleteEmployeeCommand).Assembly));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register Repository (If you are using repositories)
builder.Services.AddScoped<EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

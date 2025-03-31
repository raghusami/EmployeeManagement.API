namespace EmployeeManagement.Persistence;

using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
    {

    }
    public DbSet<Employee> Employees { get; set; }
}

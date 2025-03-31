namespace EmployeeManagement.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string Department { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public decimal Salary { get; private set; }

    public Employee(string name, string department, string email, string phone, decimal salary)
    {
        Name = name;
        Department = department;
        Email = email;
        Phone = phone;
        Salary = salary;

    }
    public void UpdateEmployee(string name, string department, string email, string phone, decimal salary)
    {
        Name = name;
        Department = department;
        Email = email;
        Phone = phone;
        Salary = salary;
    }
}

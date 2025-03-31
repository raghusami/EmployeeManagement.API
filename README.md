# 🚀 Employee Management API using DDD & CQRS

This repository demonstrates an **Employee Management API** built with **.NET Core**, implementing **Domain-Driven Design (DDD)** and **CQRS (Command Query Responsibility Segregation)** using **MediatR** and **Entity Framework Core**.

---

## 📌 Key Features  

✅ **DDD (Domain-Driven Design):** Organizes code into distinct layers (Domain, Application, Infrastructure).  
✅ **CQRS (Command Query Responsibility Segregation):** Separates commands (write operations) from queries (read operations).  
✅ **MediatR:** Implements the **Mediator Pattern** for command/query handling.  
✅ **EF Core with SQL Server:** Handles database operations using **ApplicationDbContext**.  
✅ **Repository Pattern:** Manages data access and separation of concerns.  
✅ **Swagger Integration:** Generates interactive API documentation.  

---

## 📂 Project Structure  

```
📦 EmployeeManagement  
 ┣ 📂 API (Presentation Layer)  
 ┃ ┗ 📂 Controllers  
 ┃ ┃ ┗ EmployeeController.cs  
 ┣ 📂 Application (Application Layer - CQRS)  
 ┃ ┣ 📂 Employees  
 ┃ ┃ ┣ 📂 Commands  
 ┃ ┃ ┃ ┣ CreateEmployeeCommand.cs  
 ┃ ┃ ┃ ┣ UpdateEmployeeCommand.cs  
 ┃ ┃ ┃ ┗ DeleteEmployeeCommand.cs  
 ┃ ┃ ┣ 📂 Queries  
 ┃ ┃ ┃ ┣ GetEmployeeByIdQuery.cs  
 ┃ ┃ ┃ ┗ GetEmployeesQuery.cs  
 ┣ 📂 Domain (Domain Layer - Business Logic)  
 ┃ ┗ 📂 Entities  
 ┃ ┃ ┗ Employee.cs  
 ┣ 📂 Infrastructure (Data Layer - EF Core)  
 ┃ ┣ EmployeeDbContext.cs  
 ┃ ┗ EmployeeRepository.cs  
 ┣ 📂 Persistence (Database Context & Migrations)  
 ┃ ┗ ApplicationDbContext.cs  
 ┣ 📂 Startup (Dependency Injection & Middleware)  
 ┃ ┗ Program.cs  
```

---

## 🛠 Installation & Setup  

### 1️⃣ Clone the Repository
```sh
git clone https://github.com/yourusername/EmployeeManagementAPI.git
cd EmployeeManagementAPI
```

### 2️⃣ Configure the Database  
Update `appsettings.json` with your database connection:  
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Run the EF Core Migrations:  
```sh
dotnet ef database update
```

### 3️⃣ Run the API
```sh
dotnet run
```

### 4️⃣ Access the API Documentation  
Open your browser and navigate to:  
📌 **Swagger UI**: `http://localhost:5000/swagger`

---

## 🚀 Implementation Details  

### 1️⃣ Domain Layer (Entities & Business Logic)  
Defines the `Employee` entity:  
```csharp
public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
}
```

### 2️⃣ Application Layer (CQRS Handlers)  

📌 **Create Employee Command Handler**  
```csharp
public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _repository;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Position = request.Position,
            Salary = request.Salary
        };

        await _repository.AddAsync(employee);
        return employee.Id;
    }
}
```

📌 **Get Employees Query Handler**  
```csharp
public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<Employee>>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeesQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
```

---

## 🛠 Program.cs (Dependency Injection & Middleware Configuration)  

📌 **Registering Dependencies**  
```csharp
using EmployeeManagement.Infrastructure.Repositories;
using EmployeeManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// ✅ Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeManagement.Application.Employees.Commands.CreateEmployeeCommand).Assembly));

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
```

---

## 🏗 API Endpoints  

| Method | Endpoint | Description |
|--------|----------|-------------|
| **GET** | `/api/employees` | Retrieve all employees |
| **GET** | `/api/employees/{id}` | Retrieve a specific employee |
| **POST** | `/api/employees` | Create a new employee |
| **PUT** | `/api/employees/{id}` | Update an existing employee |
| **DELETE** | `/api/employees/{id}` | Delete an employee |

---

## 📢 Contributing  
- Fork this repository  
- Create a new branch (`git checkout -b feature-branch`)  
- Commit your changes (`git commit -m "Add new feature"`)  
- Push to the branch (`git push origin feature-branch`)  
- Open a Pull Request  

🌟 **Star this repository if you found it helpful!** 🚀

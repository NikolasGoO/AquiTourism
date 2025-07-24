# AquiTourism

**AquiTourism** is a modern API built with **.NET 8**, designed to manage tourism-related data such as attractions and operators. It follows **Clean Architecture** principles and utilizes **Entity Framework Core**, **AutoMapper**, and **Dependency Injection** to ensure modularity, testability, and scalability.

---

## ✅ Features

### 🎯 Attraction Management
- Full CRUD operations
- Custom filtering and pagination

### 👤 Operator Management
- Registration with unique **email** and **CPF** validation
- Authentication with **JWT token** generation
- Password creation, validation, and reset
- Update of operator data
- Operator deactivation and logical deletion

### 🧰 Technical Features
- RESTful API with **versioning**
- Interactive API documentation via **Swagger**
- Implements **Unit of Work** pattern for transactional consistency
- **AutoMapper** for object mapping
- Extensible architecture with separated layers:
  - Application
  - Domain
  - Infrastructure

---

## 🛠️ Technologies

- [.NET 8](https://dotnet.microsoft.com/download)
- C# 12
- Entity Framework Core
- AutoMapper
- Swagger (Swashbuckle)
- Dependency Injection
- SQL Server (default, but configurable)

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any compatible database

### Setup Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/AquiTourism.git
   cd AquiTourism
   ```

2. **Configure the database connection:**
   - File: `src/AquiTourism.API/appsettings.json`

3. **Apply database migrations:**
   ```bash
   dotnet ef database update --project src/AquiTourism.Infra.Data
   ```

4. **Run the application:**
   ```bash
   dotnet run --project src/AquiTourism.API
   ```

5. **Access Swagger UI:**
   - Open in your browser: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 📁 Project Structure

```
AquiTourism
│
├── src/
│   ├── AquiTourism.API/                # API layer (controllers, configurations)
│   ├── AquiTourism.Application/        # Application services, view models, AutoMapper
│   ├── AquiTourism.Domain/             # Domain entities and interfaces
│   ├── AquiTourism.Infra.Data/         # Repositories, EF Core, DbContext
│   ├── AquiTourism.Infra.CrossCutting/ # Dependency injection, shared utilities
│   └── AquiTourism.Core/               # Core domain objects, enums, helpers
```

---

## 📌 Usage

- Use **Swagger UI** to explore and test API endpoints
- Integrate with your **frontend or mobile app** via the documented REST API
- Operator registration enforces **email** and **CPF** uniqueness, plus password confirmation
- Authentication returns a **JWT token** for secure access
- Operators can be **deactivated** or have their password **reset** via specific endpoints

---

## 🤝 Contributing

Contributions are welcome!  
Feel free to open issues or submit pull requests for suggestions, bug fixes, or improvements.

---

## 📄 License

This project is licensed under the **MIT License**.  
See the [LICENSE](./LICENSE) file for more details.

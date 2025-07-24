# AquiTourism

**AquiTourism** is a modern **.NET 8 Web API** project designed to manage and expose tourism-related data, such as attractions and operators. The solution follows clean architecture principles, leveraging **Entity Framework Core** for data access, **AutoMapper** for object mapping, and **dependency injection** for modularity and testability.

---

## ✅ Features

- **Attraction Management:** CRUD operations for tourism attractions, including filtering and pagination  
- **Operator Management:** User registration, authentication, and password management for operators  
- **RESTful API:** Well-structured endpoints with versioning  
- **Swagger Integration:** Interactive API documentation  
- **Unit of Work Pattern:** Transaction management for data consistency  
- **AutoMapper:** Simplified mapping between domain entities and view models  
- **Extensible Architecture:** Separation of concerns across Application, Domain, and Infrastructure layers  

---

## 🛠️ Technologies

- **.NET 8**  
- **C# 12**  
- **Entity Framework Core**  
- **AutoMapper**  
- **Swagger (Swashbuckle)**  
- **Dependency Injection**  
- **SQL Server** (default, configurable)  

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or compatible database  

### Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/AquiTourism.git
   cd AquiTourism
   ```

2. **Configure the database:**

   - Update the connection string in:  
     `src/AquiTourism.API/appsettings.json`

3. **Apply migrations:**

   ```bash
   dotnet ef database update --project src/AquiTourism.Infra.Data
   ```

4. **Run the API:**

   ```bash
   dotnet run --project src/AquiTourism.API
   ```

5. **Access Swagger UI:**

   - Open in your browser:  
     `https://localhost:5001/swagger`

---

## 📁 Project Structure

```
AquiTourism
│
├── src/
│   ├── AquiTourism.API/                # API layer (controllers, configs)
│   ├── AquiTourism.Application/        # Application services, view models, AutoMapper
│   ├── AquiTourism.Domain/             # Domain entities, interfaces
│   ├── AquiTourism.Infra.Data/         # Data access, repositories, EF context
│   ├── AquiTourism.Infra.CrossCutting/ # IoC, shared infrastructure
│   └── AquiTourism.Core/               # Core domain objects, enums, utilities
│
└── README.md
```

---

## 📌 Usage

- Use the **Swagger UI** to explore and test API endpoints  
- Integrate with your **frontend or mobile app** using the documented REST endpoints  

---

## 🤝 Contributing

Contributions are welcome!  
Please open issues or submit pull requests for improvements and bug fixes.

---

## 📄 License

This project is licensed under the **MIT License**.

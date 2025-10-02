# Smart Pay Mobile App Backend

## Architecture Overview

This project follows **Clean Architecture** principles with the following layers:

### 📁 Project Structure

```
SmartPayMobileApp_Backend/
├── Controllers/           # API Controllers (Presentation Layer)
├── Models/
│   ├── Entities/         # Domain Models
│   └── DTOs/            # Data Transfer Objects
├── Services/
│   ├── Interfaces/      # Service Contracts
│   └── Implementations/ # Service Implementations
├── Repositories/
│   ├── Interfaces/      # Repository Contracts
│   └── Implementations/ # Repository Implementations
├── Data/               # Database Context
├── Extensions/         # Service Extensions
└── Middleware/         # Custom Middleware
```

### 🏗️ Architecture Pattern

**Clean Architecture (Layered Architecture)** with:

1. **Presentation Layer** - Controllers, DTOs
2. **Application Layer** - Services, Use Cases
3. **Domain Layer** - Entities, Business Logic
4. **Infrastructure Layer** - Data Access, External Services

### 🔧 Technology Stack

- **.NET 8.0** - Latest LTS version
- **Entity Framework Core** - Code First approach
- **SQL Server** - Database
- **Repository Pattern** - Data access abstraction
- **Service Layer** - Business logic
- **Dependency Injection** - Loose coupling

### 🚀 Setup Instructions

1. **Install Dependencies**
   ```bash
   dotnet restore
   ```

2. **Create Database Migration**
   ```bash
   dotnet ef migrations add InitialCreate
   ```

3. **Update Database**
   ```bash
   dotnet ef database update
   ```

4. **Run Application**
   ```bash
   dotnet run
   ```

### 📊 Database Configuration

- **Development**: LocalDB
- **Production**: SQL Server
- **Connection String**: Configured in `appsettings.json`

### 🔄 Code First Benefits

✅ **Version Control** - Database changes tracked in code
✅ **Team Collaboration** - Consistent schema across environments
✅ **Migration Support** - Easy database updates
✅ **Type Safety** - Compile-time checking
✅ **Future Flexibility** - Easy entity modifications

### 📝 API Endpoints

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create new user
- `PUT /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user

### 🛡️ Security Features

- Input validation
- Error handling
- Logging
- Soft delete (IsActive flag)

### 🔮 Future Enhancements

- Authentication & Authorization
- Payment processing
- Transaction management
- Audit logging
- Caching
- Rate limiting

# ASP.NET Core with Entity Framework Core Project  

This is a web application built with **ASP.NET Core** and **Entity Framework Core**, designed to showcase the implementation of a CRUD API and database operations.  

## Features  

- **Entity Framework Core** for database interaction.  
- RESTful API with endpoints for basic CRUD operations.  
- SQL Server as the database provider (configurable).  
- Dependency Injection and Middleware support.  
- Input validation and error handling.  
- Configurable logging and environment-based settings.  

## Prerequisites  

Before running the project, ensure you have the following installed:  
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or higher recommended)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any compatible database provider  
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)  

## Getting Started  

```bash  
git clone <repository-url>  
cd <project-folder>
```

### 2. Configure the Database
Update the appsettings.json file in the project root with your SQL Server connection string:

```bash
"ConnectionStrings": {  
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;"  
}
```

### 3. Apply Migrations
Run the following commands to create the database and apply migrations:

```bash
dotnet ef migrations add InitialCreate  
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

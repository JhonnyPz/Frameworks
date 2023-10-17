# 05-ASP.NET-EF
![Framework](https://img.shields.io/badge/ASP.NET-141414?&logo=dotnet&logoColor=white&labelColor=512BD4)
![Languages](https://img.shields.io/badge/C--Sharp-141414?&logo=csharp&logoColor=white&labelColor=512BD4)
![ORM](https://img.shields.io/badge/Entity_Framework-141414?&logo=dotnet&logoColor=white&labelColor=512BD4)


<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Description

The `aspnet-ef` project is an ASP.NET application that employs **Entity Framework** as the Object-Relational Mapping (ORM) tool, along with a Layered Architecture (N-Tier) design pattern to manage a database of designs. This application provides an API for accessing and manipulating design information.

### Key Features:

1. Layer Architecture (N-Tier)
1. Middlewares (CORS Policies)
1. Dependency Injection
1. Background Work
1. Entity Framework - ORM
1. AutoMapper
1. Swagger

## Table of Contents

- [Description](#description)
  - [key features](#key-features)
  - [how to use](#how-to-use)
  - [endpoints](#endpoints)
- [Technologies](#technologies-used)
- [Project Structure](#project-structure)
- [Commands](#commands)

### How to Use:

```bash
# Build and install dependencies
dotnet build

# Start the server: 
dotnet run --project ./app

# Access the API at:
http://localhost:3000
```

> **Note:** To change databases, install [Database Providers](https://learn.microsoft.com/en-us/ef/core/providers) and modify the following line in the `Program.cs` file:
```C#
// Add Layer Data
builder.Services.AddScoped<IDesignRepository, SQLiteRepository>();
```

### Endpoints:
```http
GET /design
GET /design/id

POST /design
PATCH /design/id

DELETE /design/id
```


> **Note:** Swagger is only enabled in the development environment
```bash
# Start the server with Swagger: 
dotnet run --environment Development
```

### Technologies Used:

- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors)
- [AutoMapper](https://nuget.org/packages/AutoMapper)
- [EntityFrameworkCore](https://nuget.org/packages/Microsoft.EntityFrameworkCore)
- [EntityFrameworkCore.Sqlite](https://nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite)
- [Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)

### Project Structure:

The project is organized as follows:

```
05-aspnet-ef/
├─ app/
│   ├─ Controllers/
│   ├─ MapperProfile/
│   ├─ Middlewares/
│   ├─ app.csproj
│   ├─ appsettings.json
│   └─ Program.cs
│
├─ app.Services/
│   ├─ CreateDatabase.cs
│   ├─ IUploadDesigns.cs
│   ├─ UploadDesigns.cs
│   └─ app.Services.csproj
│
├─ app.Data/
│   ├─ Interfaces/
│   ├─ Migrations/
│   ├─ Models/
│   ├─ Repositories/
│   ├─ SQLiteContext.cs
│   └─ app.Data.csproj
│
├─ app.sln
└─ Directory.Packages.props
```

### Commands:

All commands are run from the root of the project, from a terminal:

| Command                  | Action |
| -------------------------| ------ |
| `dotnet build`                           | Builds the project and its dependencies |
| `dotnet run --project ./app`             | Executes the project |
| `dotnet publish ./app -o ./publish`      | Publishes the project for deployment |
# 04-ASP.NET-Dapper
![Framework](https://img.shields.io/badge/ASP.NET-141414?&logo=dotnet&logoColor=white&labelColor=512BD4)
![Languages](https://img.shields.io/badge/C--Sharp-141414?&logo=csharp&logoColor=white&labelColor=512BD4)
![Database](https://img.shields.io/badge/PostgreSQL-141414?&logo=postgresql&logoColor=white&labelColor=4169E1)
![Database](https://img.shields.io/badge/Azure_SQL-141414?&logo=microsoftsqlserver&logoColor=white&labelColor=4169E1)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Description

The `aspnet-dapper` project is an ASP.NET application that utilizes the **Dapper ORM** (Object-Relational Mapping) along with the Model-View-Controller (MVC) architecture pattern to manage a database of books. The application provides an API for accessing and manipulating book information.

### Key Features:

1. MVC Architecture
1. Middlewares (CORS Policies)
1. Dependency Injection
1. Dapper - Minimal ORM
1. Swagger

## Table of Contents

- [Description](#description)
  - [key features](#key-features)
  - [how to use](#how-to-use)
  - [endpoints](#endpoints)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Commands](#commands)

### How to Use:

```bash
# Build and install dependencies
dotnet build

# Start the server: 
dotnet run

# Access the API at:
http://localhost:3000
```

> **Note:** To change databases from PostgreSQL to Azure SQL, modify the following line in the `Program.cs` file:
```CSharp
// Data Layer
builder.Services.AddScoped<IBookRepository, AzureRepository>();
```

### Endpoints:
```http
GET /books
GET /books/id

POST /books
PATCH /books/id

DELETE /books/id
```


> **Note:** Swagger is only enabled in the development environment
```bash
# Start the server with Swagger: 
dotnet run --environment Development
```

### Technologies Used:

- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors)
- [Dapper](https://nuget.org/packages/Dapper)
- [Npgsql](https://nuget.org/packages/Npgsql)
- [SqlClient](https://nuget.org/packages/Microsoft.Data.SqlClient)
- [Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)

### Project Structure:

The project is organized as follows:

```
04-aspnet-dapper/
├─ Controllers/
│   └─ Book.cs
├─ Middlewares/
│   └─ Cors.cs
├─ Models/
│   └─ Book.cs
├─ Data/
│   ├─ Repository/
│   │   ├─IBook.cs
│   │   ├─Azure.cs
│   │   └─Postgres.cs
│   └─ DBConnection.cs
├─ API.http
├─ app.csproj
├─ app.sln
├─ appsettings.json
└─ Program.cs
```

### Commands:

All commands are run from the root of the project, from a terminal:

| Command                  | Action |
| -------------------------| ------ |
| `dotnet build`           | Builds the project and its dependencies |
| `dotnet run`             | Executes the project |
| `dotnet publish`         | Publishes the project for deployment |
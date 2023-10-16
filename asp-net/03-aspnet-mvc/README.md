# 03-ASP.NET-MVC
![Framework](https://img.shields.io/badge/ASP.NET-141414?&logo=dotnet&logoColor=white&labelColor=512BD4)
![Languages](https://img.shields.io/badge/C--Sharp-141414?&logo=csharp&logoColor=white&labelColor=512BD4)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Description

The `aspnet-mvc`, is a C# web application built using **ASP.NET MVC framework**. It is designed to handle HTTP requests and provide dynamic web content through controllers, views, and models. The project leverages the ASP.NET Core ecosystem for robustness and flexibility.

### Key Features:

1. MVC Architecture
1. Middlewares (cors policies)
1. Validations Models
1. Deserialize Json
1. Swagger

## Table of Contents

- [Description](#description)
  - [key features](#key-features)
  - [how to use](#how-to-use)
  - [endpoints](#endpoints)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Commands](#commands)


### how to use:
```bash
# Build and install dependencies
dotnet build

# Start the server: 
dotnet run

# Access the API at
http://localhost:3000
```

### endpoints:
```http
GET /books
GET /books/id
GET /books?genre=Sci-fi

POST /books
PATCH /books/id

DELETE /books/id
```

> **Note:** Swagger is only enabled in the development environment
```bash
# Start the server with Swagger: 
dotnet run --environment Development
```


## Technologies

- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [ASP.NET Core MVC](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc)
- [CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors)
- [Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)
- [DataAnnotations](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations)

## Project Structure

```
03-aspnet-mvc/
├─ Controllers/
│   └─ Book.cs
├─ Middlewares/
│   └─ Cors.cs
├─ Models/
│   ├─ Book.cs
│   └─ Book.json
├─ Schemas/
│   ├─ Utils.cs
│   └─ Validations.cs
├─ View/
│   └─ index.html
├─ API.http
├─ app.csproj
├─ app.sln
├─ appsettings.json
└─ Program.cs
```

## Commands

All commands are run from the root of the project, from a terminal:

| Command                  | Action |
| -------------------------| ------ |
| `dotnet build`           | Builds the project and its dependencies |
| `dotnet run`             | Executes the project |
| `dotnet publish`         | Publishes the project for deployment |


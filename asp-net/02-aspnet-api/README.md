# 02-ASP.NET-API
![Framework](https://img.shields.io/badge/ASP.NET-141414?&logo=dotnet&logoColor=white&labelColor=512BD4)
![Languages](https://img.shields.io/badge/C--Sharp-141414?&logo=csharp&logoColor=white&labelColor=512BD4)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Description

The `aspnet-api` is a C# web application built on **ASP.NET Core**. Minimal API develoment, it includes CORS handling for controlled access, supports CRUD operations, and reads from a JSON file.

### Key Features:

1. **Minimal API**
1. **CORS policies**
1. **CRUD Data**
1. **JSON Deserialize**
1. **Port settings**

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
GET /languages
GET /languages/id
GET /languages?uses=Web

POST /languages
PATCH /languages/id

DELETE /languages/id
```

## Technologies

- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet/apis)
- [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json)
- [System.IO.File](https://learn.microsoft.com/en-us/dotnet/api/system.io.file)
- [System.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)

## Project Structure

```
02-aspnet-api/
├─ Models/
│   ├─ Languages.cs
│   └─ Languages.json
├─ View/
│   └─ index.html
├─ API.http
├─ app.csproj
└─ Program.cs
```

## Commands

All commands are run from the root of the project, from a terminal:

| Command                  | Action |
| -------------------------| ------ |
| `dotnet build`           | Builds the project and its dependencies |
| `dotnet run`             | Executes the project |
| `dotnet publish`         | Publishes the project for deployment |


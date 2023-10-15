# 01-ASP.NET-Tree 
![Framework](https://img.shields.io/badge/7-141414?&logo=dotnet&logoColor=white&labelColor=512BD4)
![Languages](https://img.shields.io/badge/C--Sharp-141414?&logo=csharp&logoColor=white&labelColor=512BD4)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Table of Contents

- [Description](#description)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Commands](#commands)

## Description

This is a basic **console project** 
The `Tree` project is a .NET **console application** that generates a graphical representation of the directory and file structure of a file system. It allows customization of the display depth and provides options to ignore specific directories. Additionally, it offers a clear and concise syntax for execution.

```bash
# example
app.exe  -max 3 ./path/name
```

## Technologies
- .NET 7 - Console
- System.IO.Path
- System.IO.DirectoryInfo

## Project Structure

```
01-aspnet-tree/
├── app.csproj
├── app.sln
└── Program.cs
```

## Commands

All commands are run from the root of the project, from a terminal:

| Command                  | Action |
| -------------------------| ------ |
| `dotnet build`           | Builds the project and its dependencies |
| `dotnet run`             | Executes the project |
| `dotnet publish`         | Publishes the project for deployment |


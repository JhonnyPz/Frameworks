# 03-NodeJS-MVC 
![Framework](https://img.shields.io/badge/Express-141414?&logo=express&logoColor=white&labelColor=339933)
![Languages](https://img.shields.io/badge/JavaScript-141414?&logo=javascript&logoColor=white&labelColor=F7DF1E)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

### Key Features:

1. MVC Architecture
1. Middlewares (cors policies)
1. Routes and Controllers
1. Models and Schemas
1. Port settings

## Table of Contents

- [Description](#description)
  - [key features](#key-features)
  - [how to use](#how-to-use)
  - [endpoints](#endpoints)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Commands](#commands)

## Description

The `nodejs-mvc` project is a Node.js based API application designed with the **Model-View-Controller (MVC) architectural pattern**. It provides a structured framework for building scalable and maintainable web applications.

### how to use:
```bash
# Install dependencies
npm install

# Start the server: 
npm run dev

# Access the API at
http://localhost:3000
```

### endpoints:
```http
GET /movies
GET /movies/id
GET /movies?genre=Sci-Fi

POST /movies
PATCH /movies/id

DELETE /movies/id
```

## Technologies

- [Node.JS - v18](https://nodejs.org/en)
- [express](https://expressjs.com/)
- [cors](https://npmjs.com/package/cors)
- [zod](https://npmjs.com/package/zod)
- [node:crypto](https://nodejs.org/api/crypto.html)

## Project Structure

```
03-nodejs-mvc/
├─ controllers/
│   └─ movies.js
├─ middlewares/
│   └─ cors.js
├─ models/
│   └─ movie.js
├─ routes/
│   └─ movies.js
├─ schemas/
│   └─ movies.js
├─ views/
│   └─ index.html
├─ api.http
├─ app.js
├─ package.json
└─ movies.json
```

## Commands

All commands are run from the root of the project, from a terminal:

| Command                  | Action |
| -------------------------| ------ |
| `npm install`            | Install project dependencies |
| `npm run dev`            | Start the development server at `localhost:3000` |


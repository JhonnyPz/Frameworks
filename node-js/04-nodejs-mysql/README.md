# 03-NodeJS-MVC 
![Framework](https://img.shields.io/badge/Express-141414?&logo=express&logoColor=white&labelColor=339933)
![Languages](https://img.shields.io/badge/JavaScript-141414?&logo=javascript&logoColor=white&labelColor=F7DF1E)
![Database](https://img.shields.io/badge/MySQL-141414?&logo=mysql&logoColor=white&labelColor=4479A1)
![Database](https://img.shields.io/badge/SQLite-141414?&logo=sqlite&logoColor=white&labelColor=003B57)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Description

The `nodejs-mysql` project is a Node.js application that utilizes the Model-View-Controller (MVC) architecture pattern and **dependency injection** to manage the databases of movies. The application provides an API for accessing and manipulating movie information.

### Key Features:

1. MVC Architecture
1. Middlewares (cors policies)
1. Dependency injection
1. Zod validation
1. Port settings

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
# Install dependencies
npm install

# Start the server with sqlite: 
npm run dev

# Start the server with mysql: 
npm run prod

# Access the API at
http://localhost:3000
```

### endpoints:
```http
GET /movies
GET /movies/id

POST /movies
PATCH /movies/id

DELETE /movies/id
```

## Technologies

- [Node.JS](https://nodejs.org/en)
- [express](https://expressjs.com/)
- [cors](https://npmjs.com/package/cors)
- [zod](https://npmjs.com/package/zod)
- [mysql2](https://npmjs.com/package/mysql2)
- [sqlite3](https://npmjs.com/package/sqlite3)
- [node:crypto](https://nodejs.org/api/crypto.html)

## Project Structure

```
04-nodejs-mysql/
├─ controllers/
│   └─ movies.js
├─ middlewares/
│   └─ cors.js
├─ routes/
│   └─ movies.js
├─ schemas/
│   └─ movies.js
├─ views/
│   └─ index.html
│
├─ models/
│   ├─ mysql/
│   │   └─ movie.js
│   └─ sqlite/
│       └─ movie.js
│
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
| `npm run dev`            | Start the development server with SQLite |
| `npm run prod`           | Start the production server with MySQL |


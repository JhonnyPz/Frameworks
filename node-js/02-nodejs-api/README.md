# 02-NodeJS-API 
![Framework](https://img.shields.io/badge/Express-141414?&logo=express&logoColor=white&labelColor=339933)
![Languages](https://img.shields.io/badge/JavaScript-141414?&logo=javascript&logoColor=white&labelColor=F7DF1E)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Table of Contents

- [Description](#description)
  - [how to use](#how-to-use)
  - [endpoints](#endpoints)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Commands](#commands)

## Description

The `nodejs-api` is a robust **Node.js API** for managing movies. It offers CRUD operations, genre filtering, and secure HTTP handling. Utilizing Express and crypto, it ensures efficient movie management with unique IDs.

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
02-nodejs-api/
├─ schemas/
│   └─ movies.js
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


# 05-NodeJS-WebSocket
![Framework](https://img.shields.io/badge/Express-141414?&logo=express&logoColor=white&labelColor=339933)
![Languages](https://img.shields.io/badge/JavaScript-141414?&logo=javascript&logoColor=white&labelColor=F7DF1E)
![Librery](https://img.shields.io/badge/Socket.IO-141414?&logo=socketdotio&logoColor=white&labelColor=010101)
![Database](https://img.shields.io/badge/SQLite-141414?&logo=sqlite&logoColor=white&labelColor=003B57)

<!-- ## Preview
![001-specex](../assets/001-spacex.jpg) -->

## Description

The `nodejs-websocket` project is a Node.js application that implements a **real-time** chat system using **websockets**. It follows a client-server architecture and utilizes the Socket.IO library for websocket communication. The application also features logging functionality.

### Key Features:

1. Client-Server Architecture
1. Socket
1. Logs

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

# Access the API at
http://localhost:3000
```

### endpoints:
```http
GET /
```

## Technologies

- [Node.JS](https://nodejs.org/en)
- [express](https://expressjs.com/)
- [socket.io](https://npmjs.com/package/socket.io)
- [sqlite3](https://npmjs.com/package/sqlite3)
- [morgan](https://npmjs.com/package/morgan)

## Project Structure

```
05-nodejs-websocket/
├─ client/
│   └─ index.html
│
├─ server/
│   └─ index.js/
│
└─ package.json

```

## Commands

All commands are run from the root of the project, from a terminal:

| Command                  | Action |
| -------------------------| ------ |
| `npm install`            | Install project dependencies |
| `npm run dev`            | Start the development server |

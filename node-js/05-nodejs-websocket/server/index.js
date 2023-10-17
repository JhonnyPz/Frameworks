import express from 'express'
import logger from 'morgan'
import { Server } from 'socket.io'
import { createServer } from 'node:http'
import sqlite from 'sqlite3'


const port = process.env.PORT ?? 3000

const app = express()
const server = createServer(app)
const io = new Server(server, {
  connectionStateRecovery: {}
})

const SQLite = sqlite.verbose()
const db = new SQLite.Database('chat.db')

db.exec(`
  CREATE TABLE IF NOT EXISTS messages (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    content TEXT,
    user TEXT
  )
`)

io.on('connection', (socket) => {
  console.log('a user has connected!')

  socket.on('disconnect', () => {
    console.log('a user has disconnected!')
  })

  socket.on('chat message', (msg) => {
    let result
    const username = socket.handshake.auth.username ?? 'anonymous'
    console.log({ username })
    try {
      result = db.run(
        'INSERT INTO messages (content, user) VALUES (?, ?)',
        [msg, username]
      )
    } catch (e) {
      console.error(e)
      return
    }

    io.emit('chat message', msg, result.lastID, username)
  })

  if (!socket.recovered) {
    try {
      db.each(
        'SELECT id, content, user FROM messages WHERE id > ?',
        [socket.handshake.auth.serverOffset ?? 0],
        (err, row) => {
          socket.emit('chat message', row.content, row.id.toString(), row.user)
        }
      )
    } catch (e) {
      console.error(e)
    }
  }
})

app.use(logger('dev'))

app.get('/', (req, res) => {
  res.sendFile(process.cwd() + '/client/index.html')
})

server.listen(port, () => {
  console.log(`Server runing on port ${port}`)
})
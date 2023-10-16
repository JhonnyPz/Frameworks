import express, { json } from 'express'
import { corsMiddleware } from './middlewares/cors.js'
import { createMovieRouter } from './routes/movies.js'

export const createApp = ({ movieModel }) => {
  const app = express()
  app.use(json())
  app.disable('x-powered-by')
  app.use(corsMiddleware())

  // Resource all movies
  app.use('/movies', createMovieRouter({ movieModel }))

  const PORT = process.env.PORT ?? 3000

  app.listen(PORT, () => {
    console.log(`Server listening on port http://localhost:${PORT}`)
  })
}

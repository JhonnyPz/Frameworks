import { createApp } from './app.js'
import { MovieModel } from './models/sqlite/movie.js'

createApp({ movieModel: MovieModel })

import { randomUUID } from 'node:crypto'
import { promisify } from 'node:util'
import sqlite from 'sqlite3'

const SQLite = sqlite.verbose()
const db = new SQLite.Database('movies.db')

db.exec(`
  CREATE TABLE IF NOT EXISTS movies (
    id TEXT PRIMARY KEY,
    title TEXT NOT NULL,
    year INTEGER NOT NULL,
    director TEXT NOT NULL,
    duration INTEGER NOT NULL,
    poster TEXT,
    rate REAL NOT NULL
  )
`)

export class MovieModel {
  static async getAll() {
    const query = promisify(db.all).bind(db);
    const movies = await query(
      'SELECT title, year, director, duration, poster, rate, id FROM movies;'
    )

    return movies
  }

  static async getById({ id }) {
    const query = promisify(db.get).bind(db);
    const movie = await query(
      `SELECT title, year, director, duration, poster, rate, id 
        FROM movies WHERE id = ?;`,
      [id]
    )

    if (movie.length === 0) return null

    return movie
  }

  static async create({ input }) {
    const {
      title,
      year,
      duration,
      director,
      rate,
      poster
    } = input

    const uuid = randomUUID()

    try {
      const query = promisify(db.run).bind(db);

      await query(
        `INSERT INTO movies (id, title, year, director, duration, poster, rate)
          VALUES (?, ?, ?, ?, ?, ?, ?);`,
        [uuid, title, year, director, duration, poster, rate]
      )
    } catch (e) {
      throw new Error('Error creating movie')
    }

    const query = promisify(db.get).bind(db);
    const movies = await query(
      `SELECT title, year, director, duration, poster, rate, id
        FROM movies WHERE id = ?;`,
      [uuid]
    )

    return movies
  }

  static async delete({ id }) {
    try {
      const query = promisify(db.run).bind(db);
      await query(
        'DELETE FROM movies WHERE id = ?;',
        [id]
      )
    } catch (e) {
      throw new Error('Error deleting movie')
    }

    return true
  }

  static async update({ id, input }) {
    const queryget = promisify(db.get).bind(db);
    const movies = await queryget(
      'SELECT title, year, director, duration, poster, rate FROM movies WHERE id = ?;',
      [id]
    )

    if (movies.length === 0) return null

    const updateMovie = {
      ...movies[0],
      ...input
    }

    const {
      title,
      year,
      duration,
      director,
      rate,
      poster
    } = updateMovie

    const query = promisify(db.run).bind(db);
    await query(
      `UPDATE movies 
      SET title = ?, year = ?, director = ?, duration = ?, poster = ?, rate = ?
      WHERE id = ?;`,
      [title, year, director, duration, poster, rate, id]
    )

    return updateMovie
  }
}

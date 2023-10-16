import mysql from 'mysql2/promise'

const DEFAULT_CONFIG = {
  host: 'localhost',
  user: 'root',
  port: 3306,
  password: 'password',
  database: 'moviesdb'
}

const connectionString = process.env.DB_CONNECTION_STRING ?? DEFAULT_CONFIG

const connection = await mysql.createConnection(connectionString)

export class MovieModel {
  static async getAll() {
    const [movies] = await connection.query(
      'SELECT title, year, director, duration, poster, rate, BIN_TO_UUID(id) id FROM movie;'
    )

    return movies
  }

  static async getById({ id }) {
    const [movies] = await connection.query(
      `SELECT title, year, director, duration, poster, rate, BIN_TO_UUID(id) id 
        FROM movie WHERE id = UUID_TO_BIN(?);`,
      [id]
    )

    if (movies.length === 0) return null

    return movies[0]
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

    const [uuidResult] = await connection.query('SELECT UUID() uuid;')
    const [{ uuid }] = uuidResult

    try {
      await connection.query(
        `INSERT INTO movie (id, title, year, director, duration, poster, rate)
          VALUES (UUID_TO_BIN(?), ?, ?, ?, ?, ?, ?);`,
        [uuid, title, year, director, duration, poster, rate]
      )
    } catch (e) {
      throw new Error('Error creating movie')
    }

    const [movies] = await connection.query(
      `SELECT title, year, director, duration, poster, rate, BIN_TO_UUID(id) id
        FROM movie WHERE id = UUID_TO_BIN(?);`,
      [uuid]
    )

    return movies[0]
  }

  static async delete({ id }) {
    try {
      await connection.query(
        'DELETE FROM movie WHERE id = UUID_TO_BIN(?);',
        [id]
      )
    } catch (e) {
      throw new Error('Error deleting movie')
    }

    return true
  }

  static async update({ id, input }) {
    const [movies] = await connection.query(
      'SELECT title, year, director, duration, poster, rate FROM movie WHERE id = UUID_TO_BIN(?);',
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

    await connection.query(
      `UPDATE movie 
      SET title = ?, year = ?, director = ?, duration = ?, poster = ?, rate = ?
      WHERE id = UUID_TO_BIN(?);`,
      [title, year, director, duration, poster, rate, id]
    )

    return updateMovie
  }
}

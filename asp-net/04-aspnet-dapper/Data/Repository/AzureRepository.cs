using Dapper;
using System.Data.SqlClient;
using app.Models;

namespace app.Data.Repositories;

class AzureRepository : IBookRepository
{
  private readonly DBConnection Connection;

  public AzureRepository(DBConnection _connectionString)
  {
    Connection = _connectionString;
  }

  protected SqlConnection dbconnection()
  {
    return new SqlConnection(Connection.ConnectionString);
  }

  public async Task<IEnumerable<Book>> GetAll()
  {
    var connection = dbconnection();
    var query = @"SELECT title, author, pages, year, cover, 
                  CONVERT(VARCHAR(36), id) as id FROM books";

    return await connection.QueryAsync<Book>(query);
  }

  public async Task<Book> GetById(string id)
  {
    var connection = dbconnection();
    var query = @"SELECT title, author, pages, year, cover, 
                  CONVERT(VARCHAR(36), id) as id FROM books 
                  WHERE id = CONVERT(UNIQUEIDENTIFIER, @Id)";

    return await connection.QueryFirstOrDefaultAsync<Book>(query, new { Id = id });
  }

  public async Task<Book> Create(Book newBook)
  {
    newBook.Id = Guid.NewGuid().ToString();

    var connection = dbconnection();
    var query = @"INSERT INTO books (id, title, author, pages, year, cover) 
                  VALUES( CONVERT(VARCHAR(36), @Id), @Title, @Author, @Pages, @Year, @Cover)";

    await connection.ExecuteAsync(query, newBook);

    return await GetById(newBook.Id);
  }

  public async Task<Book> Update(string id, Book updateBook)
  {
    updateBook.Id = id;

    var connection = dbconnection();
    var query = @"UPDATE books 
                SET title=@Title, author=@Author, pages=@Pages, year=@Year, cover=@Cover 
                WHERE id = CONVERT(UNIQUEIDENTIFIER, @Id)";

    await connection.ExecuteAsync(query, updateBook);

    return await GetById(updateBook.Id);
  }

  public async Task<bool> Delete(string id)
  {
    var connection = dbconnection();
    var query = "DELETE FROM books WHERE id = CONVERT(UNIQUEIDENTIFIER, @Id)";

    return await connection.ExecuteAsync(query, new { Id = id }) > 0;
  }

}
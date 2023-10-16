using app.Models;

namespace app.Data.Repositories;

public interface IBookRepository
{
  Task<IEnumerable<Book>> GetAll();
  Task<Book> GetById(string id);
  Task<Book> Create(Book newBook);
  Task<Book> Update(string id, Book updateBook);
  Task<bool> Delete(string id);
}
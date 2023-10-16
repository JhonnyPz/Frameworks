using System.ComponentModel.DataAnnotations;
using app.Schemas;

namespace app.Models;

public class Book
{
  public string? id { get; set; }
  [DataType(DataType.Text)] // [Required(ErrorMessage = "Title is required")]
  public string? title { get; set; }
  [DataType(DataType.Text)] // [Required(ErrorMessage = "Author is required")]
  public string? author { get; set; }
  [Range(0, 1000)]
  public int? pages { get; set; }
  [Url]
  public string? cover { get; set; }
  [MaxLength(300)]
  public string? synopsis { get; set; }
  [Range(0, 2024)]
  public int? year { get; set; }
  [Validations(new string[] { "sci-fi", "Terror", "Fantasy", "Zombies", "Poema épico" })]
  public string[]? genre { get; set; }
}

public class BookModels
{
  private static List<Book> books = Utils.ReadJSON("./Models/Book.json");

  public static List<Book> GetAll(string? genre)
  {
    if (!string.IsNullOrEmpty(genre))
    {
      var bookFilter = books.Where(
        book => book.genre != null && book.genre.Any(g => g.ToLower() == genre.ToLower())
      ).ToList();

      return bookFilter;
    }
    return books;
  }

  public static Book GetById(string id)
  {
    var book = books.Find(book => book.id == id);
    return book!;
  }

  public static Book Create(Book newBook)
  {
    newBook.id = Guid.NewGuid().ToString();
    books.Add(newBook);
    return newBook;
  }

  public static Book Update(string id, Book book)
  {
    var bookIndex = books.FindIndex(book => book.id == id);
    if (bookIndex == -1)
      return null!;

    var updateBook = books[bookIndex];
    var properties = typeof(Book).GetProperties();

    foreach (var property in properties)
    {
      var value = property.GetValue(book);
      if (value != null)
      {
        property.SetValue(updateBook, value);
      }
    }

    books[bookIndex] = updateBook;
    return updateBook;
  }

  public static bool Delete(string id)
  {
    var bookIndex = books.FirstOrDefault(book => book.id == id);
    books.Remove(bookIndex!);
    return true;
  }
}
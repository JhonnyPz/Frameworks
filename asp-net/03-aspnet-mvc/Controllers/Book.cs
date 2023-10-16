using Microsoft.AspNetCore.Mvc;
using app.Models;

namespace app.Controllers;

[ApiController]
[Route("[Controller]")]
public class BooksController : ControllerBase
{
  [HttpGet(Name = "GetBooks")]
  public ActionResult<IEnumerable<Book>> GetBooks(string? genre)
  {
    return BookModels.GetAll(genre);
  }

  [HttpGet("{id}")]
  public ActionResult<Book> GetBook(string id)
  {
    var book = BookModels.GetById(id);
    if (book == null)
      return NotFound(new { message = "Book not found" });

    return book;
  }

  [HttpPost]
  public ActionResult<Book> CreateBook([FromBody] Book book)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var newBook = BookModels.Create(book);
    return CreatedAtAction(nameof(GetBook), new { newBook.id }, newBook);
  }

  [HttpPatch("{id}")]
  public ActionResult<Book> PatchBook(string id, [FromBody] Book book)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var updateBook = BookModels.Update(id, book);
    if (updateBook == null)
      return NotFound(new { message = "Book not found" });

    return updateBook;
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteBook(string id)
  {
    var result = BookModels.Delete(id);
    if (!result)
      return NotFound(new { message = "Book not found" });

    return Ok(new { message = "Book  deleted" });
  }
}
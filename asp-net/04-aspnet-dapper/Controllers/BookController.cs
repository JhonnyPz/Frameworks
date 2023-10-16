using Microsoft.AspNetCore.Mvc;
using app.Data.Repositories;
using app.Models;

namespace app.Controllers;

[ApiController]
[Route("[Controller]")]
public class BooksController : ControllerBase
{
  private readonly IBookRepository BookRepository;

  public BooksController(IBookRepository _bookRepository)
  {
    BookRepository = _bookRepository;
  }

  [HttpGet(Name = "GetBooks")]
  public async Task<ActionResult> GetBooks()
  {
    return Ok(await BookRepository.GetAll());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> GetBook(string id)
  {
    var book = await BookRepository.GetById(id);
    if (book == null)
      return BookNotFound(id);

    return Ok(book);
  }

  [HttpPost]
  public async Task<ActionResult> CreateBook([FromBody] Book book)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var newBook = await BookRepository.Create(book);
    return CreatedAtAction(nameof(GetBook), new { newBook.Id }, newBook);
  }

  [HttpPatch("{id}")]
  public async Task<ActionResult> PatchBook(string id, [FromBody] Book book)
  {
    if (id != book.Id)
      return BadRequest(new { message = $"The ID({id}) does not match the book ID({book.Id})" });

    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var updateBook = await BookRepository.Update(id, book);
    if (updateBook == null)
      return BookNotFound(id);

    return Ok(updateBook);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteBook(string id)
  {
    var result = await BookRepository.Delete(id);
    if (!result)
      return BookNotFound(id);

    return Ok(new { message = "Book deleted" });
  }

  [ApiExplorerSettings(IgnoreApi = true)]
  public NotFoundObjectResult BookNotFound(string id)
  {
    return NotFound(new { message = $"The book with ID = {id} does not exist" });
  }
}
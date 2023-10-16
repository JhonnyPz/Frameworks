using System.ComponentModel.DataAnnotations;

namespace app.Models;

public class Book
{
  public string? Id { get; set; }
  [MaxLength(255), Required(ErrorMessage = "Title is required")]
  public string? Title { get; set; }
  [MaxLength(255), Required(ErrorMessage = "Author is required")]
  public string? Author { get; set; }
  [Range(1, 1000), Required(ErrorMessage = "Pages is required")]
  public int? Pages { get; set; }
  [Range(1, 2024), Required(ErrorMessage = "Year is required")]
  public int? Year { get; set; }
  [MaxLength(1000), Url]
  public string? Cover { get; set; }
}
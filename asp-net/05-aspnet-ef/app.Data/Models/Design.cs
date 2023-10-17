using System.ComponentModel.DataAnnotations;

namespace app.Data.Models;

public class Design
{
  [Required]
  public string? Id { get; set; }
  [Required, MaxLength(30)]
  public string? Title { get; set; }
  [Required, MaxLength(255)]
  public string? Prompt { get; set; }
  [Required, MaxLength(255)]
  public string? StylePrompt { get; set; }
  [Required, Url]
  public string? ImageInspirations { get; set; }
}
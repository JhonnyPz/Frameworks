namespace app.Data.Models;

public partial class DesignRequest
{
  public string? Version { get; set; }
  public string? Locales { get; set; }
  public List<Inspiration>? Inspirations { get; set; }
}

public partial class Inspiration
{
  public string? Id { get; set; }
  public Title? Title { get; set; }
  public string? Prompt { get; set; }
  public string? Style_prompt { get; set; }
  public Thumbnail? Thumbnail { get; set; }
}

public partial class Title
{
  public string? DefaultMessage { get; set; }
}

public partial class Thumbnail
{
  public string? Url { get; set; }
}

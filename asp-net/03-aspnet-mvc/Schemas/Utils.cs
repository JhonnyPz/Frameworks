using System.Text.Json;
using app.Models;

public static class Utils
{
  // Read Json File and Convert to Object
  public static List<Book> ReadJSON(string path)
  {
    return JsonSerializer.Deserialize<List<Book>>(
      File.ReadAllText(path)
    )!;
  }
}
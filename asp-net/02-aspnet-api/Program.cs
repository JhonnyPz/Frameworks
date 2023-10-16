using System.Text.Json;

//Builder
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

//Middleware
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(policy =>
  {
    policy
    .AllowAnyOrigin();
  });
  options.AddPolicy(name: "AllowAnyMethod", policy =>
  {
    policy
    .WithOrigins("http://localhost:3000", "http://localhost:8080")
    .AllowAnyMethod();
  });
});
var app = builder.Build();

// Read Json File and Convert to Object
string jsonString = File.ReadAllText("./Models/Languages.json");
var languages = JsonSerializer.Deserialize<List<Language>>(jsonString)!;

// app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod());
app.UseCors("AllowAnyMethod");

app.MapGet("/languages", (string? uses) =>
{
  //Filter by uses
  if (!string.IsNullOrEmpty(uses))
  {
    var filter = languages.Where(
      language => language.uses != null && language.uses.Any(g => g.ToLower() == uses.ToLower())
    );
    return Results.Json(filter);
  }
  return Results.Json(languages);
});

app.MapGet("/languages/{id}", (string id) =>
{
  var language = languages.Find(language => language.id == id);
  if (language == null) return Results.NotFound(new { message = "Language not found" });

  return Results.Json(language);
});

app.MapPost("/languages", (Language newLanguage) =>
{
  newLanguage.id = Guid.NewGuid().ToString();
  languages.Add(newLanguage);
  return Results.Created($"/languages/{newLanguage.id}", newLanguage);
});

app.MapPatch("/languages/{id}", (string id, Language newLanguage) =>
{
  var updateLanguage = languages.FirstOrDefault(language => language.id == id);
  if (updateLanguage == null)
  {
    return Results.NotFound(new { message = "Language not found" });
  }

  var properties = typeof(Language).GetProperties();
  foreach (var property in properties)
  {
    var newValue = property.GetValue(newLanguage);
    if (newValue != null)
    {
      property.SetValue(updateLanguage, newValue);
    }
  }

  return Results.Json(updateLanguage);
});

app.MapDelete("/languages/{id}", (string id) =>
{
  var languageIndex = languages.FirstOrDefault(language => language.id == id);
  if (languageIndex == null)
  {
    return Results.NotFound(new { message = "Language not found" });
  }

  languages.Remove(languageIndex);
  return Results.Json(new { message = "Language  deleted" });
});

// Set port and run app
string PORT = Environment.GetEnvironmentVariable("PORT") ?? "3000";
app.Run($"http://localhost:{PORT}");

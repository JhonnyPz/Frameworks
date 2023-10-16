using app.Data;
using app.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Configurations of middleware
builder.Services.AddCorsMiddleware();

// DBContext
builder.Services.AddSingleton(new DBConnection(
  Environment.GetEnvironmentVariable("DB_CONNECTION") ??
  builder.Configuration.GetConnectionString("Default")!
));

// Data Layer
builder.Services.AddScoped<IBookRepository, PostgresRepository>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("AllowWithOrigins");

app.MapControllers();

string PORT = Environment.GetEnvironmentVariable("PORT") ?? "3000";
app.Run($"http://localhost:{PORT}");

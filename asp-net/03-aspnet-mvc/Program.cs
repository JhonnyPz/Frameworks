var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Configurations of Middleware
builder.Services.AddCorsMiddleware();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Middleware
app.UseCors("AllowAnyMethod");

app.MapControllers();

string PORT = Environment.GetEnvironmentVariable("PORT") ?? "3000";
app.Run($"http://localhost:{PORT}");

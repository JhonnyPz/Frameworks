using Microsoft.EntityFrameworkCore;
using app.Middlewares;
using app.Services;
using app.Data;
using app.Data.Interfaces;
using app.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add Configurations of middleware
builder.Services.AddCorsMiddleware();
builder.Services.AddAutoMapperMiddleware();

// Add Layer App
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DBContext
builder.Services.AddDbContext<SQLiteContext>(options =>
  options.UseSqlite(
    Environment.GetEnvironmentVariable("DB_CONNECTION") ??
    builder.Configuration.GetConnectionString("Default")
));

// Add Layer Data
builder.Services.AddScoped<IDesignRepository, SQLiteRepository>();

// Add Layer Service
builder.Services.AddHostedService<CreateDatabase>()
  .AddSingleton<IUploadDesigns, UploadDesigns>();

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

public static class CorsMiddleware
{
  public static void AddCorsMiddleware(this IServiceCollection services)
  {
    services.AddCors(options =>
    {
      options.AddDefaultPolicy(policy =>
      {
        policy.AllowAnyOrigin();
      });
      options.AddPolicy(name: "AllowAnyMethod", policy =>
      {
        policy
        .WithOrigins("http://localhost:3000", "http://localhost:8080")
        .AllowAnyMethod();
      });
    });
  }
}
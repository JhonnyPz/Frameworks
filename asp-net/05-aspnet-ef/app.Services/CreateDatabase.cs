using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using app.Data;

namespace app.Services;

public class CreateDatabase : BackgroundService
{
  readonly string _url = "https://clio-assets.adobe.com/clio-playground/image-inspirations/v5/content.json";

  readonly ILogger<CreateDatabase> _logger;
  readonly IServiceScopeFactory _scopeFactory;

  public CreateDatabase(ILogger<CreateDatabase> logger, IServiceScopeFactory scopeFactory)
  {
    _logger = logger;
    _scopeFactory = scopeFactory;
  }

  protected async override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    _logger.LogInformation("Checking Database at: {time}", DateTimeOffset.Now);

    using (var scope = _scopeFactory.CreateScope())
    {
      var services = scope.ServiceProvider;
      try
      {
        var _createDatabase = services.GetRequiredService<SQLiteContext>();
        var created = _createDatabase.Database.EnsureCreated();

        if (created)
        {
          _logger.LogInformation("Creating DB at: {time}", DateTimeOffset.Now);

          var _uploadDesigns = services.GetRequiredService<IUploadDesigns>();
          await _uploadDesigns.CreateTestUploadDesigns(_url);
        }
      }
      catch (Exception ex)
      {
        var logger = services.GetRequiredService<ILogger<SQLiteContext>>();
        logger.LogError("An error occurred when creating the DB", ex);
      }
    }

    _logger.LogInformation("Running DB at: {time}", DateTimeOffset.Now);
    await Task.CompletedTask;
  }
}
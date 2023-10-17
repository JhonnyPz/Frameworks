using AutoMapper;
using app.MapperProfiles;

namespace app.Middlewares;

public static class AutoMapperMiddleware
{
  public static void AddAutoMapperMiddleware(this IServiceCollection services)
  {
    var mapperConfig = new MapperConfiguration(m =>
    {
      m.AddProfile(new MappingProfile());
    });
    IMapper mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);
  }
}


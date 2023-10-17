using System.Text.Json;
using System.Text.Json.Nodes;
using AutoMapper;
using app.Data.Interfaces;
using app.Data.Models;

namespace app.Services;

public class UploadDesigns : IUploadDesigns
{
  private readonly IMapper _mapper;
  private readonly IDesignRepository _designRepository;

  public UploadDesigns(IMapper mapper, IDesignRepository DesignRepository)
  {
    _mapper = mapper;
    _designRepository = DesignRepository;
  }

  public async Task CreateTestUploadDesigns(string url)
  {
    DesignRequest designRequests = await GetDesigns(url);
    designRequests.Inspirations!.ForEach(async design =>
    {
      Design newDesign = _mapper.Map<Design>(design);
      await _designRepository.Create(newDesign);
    });
  }

  private async Task<DesignRequest> GetDesigns(string url)
  {
    DesignRequest designRequest = new();
    var client = new HttpClient();

    using (var response = await client.GetAsync(url))
    {
      response.EnsureSuccessStatusCode();

      // Array
      // string body = await response.Content.ReadAsStringAsync().Result;
      // var data = JsonNode.Parse(body)!["inspirations"]!.AsArray().Take(30).ToList();

      // Deserialize
      string body = await response.Content.ReadAsStringAsync();
      designRequest = JsonSerializer.Deserialize<DesignRequest>(body,
        new JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        }
      )!;
    }
    return designRequest;
  }
}
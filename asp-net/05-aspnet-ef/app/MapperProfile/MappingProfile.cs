using app.Data.Models;
using AutoMapper;

namespace app.MapperProfiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Inspiration, Design>()
      .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
      .ForMember(d => d.Title, o => o.MapFrom(s => s.Title!.DefaultMessage))
      .ForMember(d => d.Prompt, o => o.MapFrom(s => s.Prompt))
      .ForMember(d => d.StylePrompt, o => o.MapFrom(s => s.Style_prompt))
      .ForMember(d => d.ImageInspirations, o => o.MapFrom(s => s.Thumbnail!.Url));
  }
}

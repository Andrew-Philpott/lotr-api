using AutoMapper;
using Lotr.Entities;
using Lotr.Models;

namespace Lotr.Helpers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Character, ViewCharacter>();

      CreateMap<CreateCharacter, Character>();

      CreateMap<UpdateCharacter, Character>();
    }
  }
}
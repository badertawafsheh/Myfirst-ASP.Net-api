using AutoMapper;
using first_web_api.DTOs.Character;
using models.first_web_api;

namespace first_web_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();

        }
    }
}

using AutoMapper;
using first_web_api.DTOs.Character;
using first_web_api.DTOs.Skill;
using first_web_api.DTOs.Weapon;
using first_web_api.Models;
using models.first_web_api;

namespace first_web_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill , GetSkillDto>();


        }
    }
}

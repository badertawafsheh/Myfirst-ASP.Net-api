using first_web_api.DTOs.Character;
using first_web_api.Models;
using models.first_web_api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace first_web_api.Services.CharacterService
{
    public interface ICharcterService
    {
        // GetCharacterDto like Character  but now i wanna to send the user every thing expect id so in add character i will send the add charcterDto 
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
        Task<ServiceResponse<GetCharacterDto>> AddCharachterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}

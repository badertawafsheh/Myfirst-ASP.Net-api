using first_web_api.Models;
using models.first_web_api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace first_web_api.Services.CharacterService
{
    public interface ICharcterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<Character>> GetCharacterByID(int id);
        Task<ServiceResponse<Character>> GetFirstCharacter();
        Task<ServiceResponse<Character>> GetSecondCharacter();

        Task<ServiceResponse<List<Character>>> AddCharacters(Character newCharacter);

    }
}

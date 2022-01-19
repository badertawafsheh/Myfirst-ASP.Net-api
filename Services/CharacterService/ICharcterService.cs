using models.first_web_api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace first_web_api.Services.CharacterService
{
    public interface ICharcterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterByID(int id);
        Task<Character> GetFirstCharacter();
        Task<Character> GetSecondCharacter();

        Task<List<Character>> AddCharacters(Character newCharacter);

    }
}

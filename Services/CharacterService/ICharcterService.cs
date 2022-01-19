using models.first_web_api;
using System.Collections.Generic;

namespace first_web_api.Services.CharacterService
{
    public interface ICharcterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterByID(int id);
        Character GetFirstCharacter();
        Character GetSecondCharacter();

        List<Character> AddCharacters(Character newCharacter);

    }
}

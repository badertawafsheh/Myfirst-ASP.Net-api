using models.first_web_api;
using System.Collections.Generic;
using System.Linq;

namespace first_web_api.Services.CharacterService
{
    public class CharacterService : ICharcterService
    {
        private static List<Character> Test = new List<Character>()
        {
            new Character(),
            new Character{Id=1,Name="Bilal"},
            new Character{Id=2,Name="Nader" , age=24}

        };
        public List<Character> AddCharacters(Character newCharacter)
        {
            Test.Add(newCharacter);
            return Test;
        }

        public List<Character> GetAllCharacters()
        {
            return Test;
        }

        public Character GetCharacterByID(int id)
        {
            return Test.FirstOrDefault(c => c.Id == id);
        }

        public Character GetFirstCharacter()
        {
            return Test[0];
        }

        public Character GetSecondCharacter()
        {
            return Test[1];       
        }
    }
}

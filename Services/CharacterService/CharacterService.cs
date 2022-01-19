using models.first_web_api;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<List<Character>> AddCharacters(Character newCharacter)
        {
            Test.Add(newCharacter);
            return Test;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return Test;
        }

        public async Task<Character> GetCharacterByID(int id)
        {
            return Test.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Character> GetFirstCharacter()
        {
            return Test[0];
        }

        public async Task<Character> GetSecondCharacter()
        {
            return Test[1];       
        }
    }
}

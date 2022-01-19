using first_web_api.Models;
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
        public async Task<ServiceResponse<List<Character>>> AddCharacters(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            Test.Add(newCharacter);
            serviceResponse.Data = Test;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = Test;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterByID(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = Test.FirstOrDefault(c => c.Id == id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetFirstCharacter()
        {
            var serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = Test[0];
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetSecondCharacter()
        {
            var serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = Test[1];
            return serviceResponse;
        }
    }
}

using AutoMapper;
using first_web_api.DTOs.Character;
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
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper; 

        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Test.Add(_mapper.Map <Character> (newCharacter));
            serviceResponse.Data = Test.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = Test.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map< GetCharacterDto >(Test.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetFirstCharacter()
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map < GetCharacterDto > (Test[0]);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetSecondCharacter()
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(Test[1]);
            return serviceResponse;
        }
    }
}

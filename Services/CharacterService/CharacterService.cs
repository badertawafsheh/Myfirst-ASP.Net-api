using AutoMapper;
using first_web_api.Data;
using first_web_api.DTOs.Character;
using first_web_api.Models;
using Microsoft.EntityFrameworkCore;
using models.first_web_api;
using System;
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
        private readonly DataContext _context;


        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            Character character = _mapper.Map<Character>(newCharacter);
            //character.Id = Test.Max(c => c.Id) + 1; // Make a unique ID and when post without ID will make by default 0 so check the max and increment by 1
            //Test.Add(character);
            _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            //serviceResponse.Data = Test.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            //First Search for character using First(throw expetion if not match ) not FirstOrDefault(return null if no matching)
            // Then Remove it from the list (which name the list is TEST ) 
            // Then return all characthers
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = Test.First(c => c.Id == id);
                Test.Remove(character);
                serviceResponse.Data = Test.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Messsage = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            //GET Characters from DB
            var dbCharacters = await _context.Characters.ToListAsync();
            //serviceResponse.Data = Test.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
                //serviceResponse.Data = _mapper.Map< GetCharacterDto >(Test.FirstOrDefault(c => c.Id == id));
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Messsage = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetFirstCharacter()
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(Test[0]);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetSecondCharacter()
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(Test[1]);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character characters = Test.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                characters.Name = updatedCharacter.Name;
                characters.Description = updatedCharacter.Description;
                characters.age = updatedCharacter.age;
                characters.Class = updatedCharacter.Class;
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Messsage = ex.Message;
            }
            return serviceResponse;
        }
    }
}

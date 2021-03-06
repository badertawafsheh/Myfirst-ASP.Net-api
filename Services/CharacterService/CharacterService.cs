using AutoMapper;
using first_web_api.Data;
using first_web_api.DTOs.Character;
using first_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using models.first_web_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _HttpContextAccessor;


        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor HttpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _HttpContextAccessor = HttpContextAccessor;
        }
        private int GetUserID() => int.Parse(_HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            Character character = _mapper.Map<Character>(newCharacter);
            //character.Id = Test.Max(c => c.Id) + 1; // Make a unique ID and when post without ID will make by default 0 so check the max and increment by 1
            //Test.Add(character);
            //serviceResponse.Data = Test.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserID());
            _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Characters
                .Where(c => c.User.Id == GetUserID())
                .Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            //First Search for character using First(throw expetion if not match ) not FirstOrDefault(return null if no matching)
            // Then Remove it from the list (which name the list is TEST ) 
            // Then return all characthers
            /* 
             //Character character = Test.First(c => c.Id == id);
             //Test.Remove(character);
             //serviceResponse.Data = Test.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
             */
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
               
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserID());
                if (character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Characters
                        .Where(c => c.User.Id == GetUserID())
                        .Select(c => _mapper.Map<GetCharacterDto>(c)).ToList(); // if i put await and toListASync will not remove it because it provides search sort ..etc not delete
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messsage = "Charachter Not Found "!;
                }
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
            var dbCharacters = await _context.Characters.Where(c => c.User.Id == GetUserID()).ToListAsync();
            //serviceResponse.Data = Test.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var dbCharacter = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c=>c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserID());
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
        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                //Character characters = Test.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                Character characters = await _context.Characters
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                if (characters.User.Id == GetUserID())
                {
                    characters.Name = updatedCharacter.Name;
                    characters.Description = updatedCharacter.Description;
                    characters.age = updatedCharacter.age;
                    characters.Class = updatedCharacter.Class;
                    serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messsage = "Charachter Not Found ";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Messsage = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddCharachterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId && c.User.Id == GetUserID());
                if (character == null)
                {
                    response.Success = false;
                    response.Messsage = "Charachter Not Found ! ";
                    return response;
                }

                var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);
                if (skill == null)
                {
                    response.Success = false;
                    response.Messsage = "Skill Not Found ! ";
                    return response;

                }
                character.Skills.Add(skill);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messsage = ex.Message;
            }
            return response;
        }
    }
}

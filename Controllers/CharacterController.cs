using Microsoft.AspNetCore.Mvc;
using models.first_web_api;
using System;
using System.Linq;
using System.Collections.Generic;
using first_web_api.Services.CharacterService;
using System.Threading.Tasks;
using first_web_api.Models;
using first_web_api.DTOs.Character;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace first_web_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharcterService _characterService;

        public CharacterController(ICharcterService characterService)
        {
            _characterService = characterService;

        }
        //[AllowAnonymous] When the methods Secure it will unlock and allow it to show the users
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharachters()
        {
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value); we create a new method to give the ID of currunt user login so no need to this 
            return Ok(await _characterService.GetAllCharacters());

        }

        // Routing using param 
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterbyId(int id)
        {
            return Ok(await _characterService.GetCharacterByID(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharachter(AddCharacterDto newCharachter)
        {
            return Ok(await _characterService.AddCharacters(newCharachter));

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharachter)
        {
            //return Ok(await _characterService.UpdateCharacter(updatedCharachter)); 
            // to return Not found if the character not found in the first case it wil send always response OK 
            var response = await _characterService.UpdateCharacter(updatedCharachter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {
            //return Ok(await _characterService.DeleteCharacter(id));
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);


        }
        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            return Ok(await _characterService.AddCharachterSkill(newCharacterSkill));
        }
   

    }

}
using Microsoft.AspNetCore.Mvc;
using models.first_web_api;
using System;
using System.Linq;
using System.Collections.Generic;
using first_web_api.Services.CharacterService;
using System.Threading.Tasks;
using first_web_api.Models;

namespace first_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
      
        private readonly ICharcterService _characterService;

        public CharacterController(ICharcterService characterService)
        {
            _characterService = characterService;

        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());

        }
        /*        
         
         *[HttpGet]
         * [Route("GetFirstItem")]
        
        */
        [HttpGet("GetFirstItem")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle()
        {
            return Ok(await _characterService.GetFirstCharacter());
        }


        [HttpGet]
        [Route("GetSecondItem")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle2()
        {
            return Ok(await _characterService.GetSecondCharacter());
        }


        // Routing using param 
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterByID(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharachter(Character newCharachter)
        {
            return Ok(await _characterService.AddCharacters(newCharachter));

        }

    }

}
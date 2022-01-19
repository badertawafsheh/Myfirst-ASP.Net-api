using Microsoft.AspNetCore.Mvc;
using models.first_web_api;
using System;
using System.Linq;
using System.Collections.Generic;
using first_web_api.Services.CharacterService;

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
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());

        }
        /*        
         
         *[HttpGet]
         * [Route("GetFirstItem")]
        
        */
        [HttpGet("GetFisrtItem")]
        public ActionResult<Character> GetSingle()
        {
            return Ok(_characterService.GetFirstCharacter());
        }


        [HttpGet]
        [Route("GetSecondItem")]
        public ActionResult<Character> GetSingle2()
        {
            return Ok(_characterService.GetSecondCharacter());
        }


        // Routing using param 
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterByID(id));
        }


        [HttpPost]
        public ActionResult<List<Character>> AddCharachter(Character newCharachter)
        {
            return Ok(_characterService.AddCharacters(newCharachter));

        }

    }

}
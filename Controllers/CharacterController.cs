using Microsoft.AspNetCore.Mvc;
using models.first_web_api;
using System;
using System.Collections.Generic;

namespace first_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        private static List<Character> Test = new List<Character>()
        {
            new Character(),    
            new Character{Name="Bilal"},
            new Character{Name="Nader" , age=24}

        };
        
        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(Test);

        }
        [HttpGet]
        [Route("GetFirstItem")]
        public ActionResult <Character> GetSingle()
        {
            return Ok(Test[0]);
        }
        [HttpGet]
        [Route("GetSecondItem")]
        public ActionResult<Character> GetSingle2()
        {
            return Ok(Test[1]);
        }


    }

}
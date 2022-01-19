using Microsoft.AspNetCore.Mvc;
using models.first_web_api;
using System;
using System.Linq;
using System.Collections.Generic;

namespace first_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> Test = new List<Character>()
        {
            new Character(),
            new Character{Id=1,Name="Bilal"},
            new Character{Id=2,Name="Nader" , age=24}

        };

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(Test);

        }
        /*        
         
         *[HttpGet]
         * [Route("GetFirstItem")]
        
        */
        [HttpGet("GetFisrtItem")]
        public ActionResult<Character> GetSingle()
        {
            return Ok(Test[0]);
        }


        [HttpGet]
        [Route("GetSecondItem")]
        public ActionResult<Character> GetSingle2()
        {
            return Ok(Test[1]);
        }


        // Routing using param 
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(Test.FirstOrDefault(c => c.Id == id));
        }

    }

}
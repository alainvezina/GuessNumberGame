﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
namespace server.Controllers
{

    [Route("")]
    [ApiController]
    [Produces("application/json")]
    public class RandomNumberController : ControllerBase
    {
        private static RandomNumber _randomNumber= new RandomNumber();
        public RandomNumberController()
        {

        }

        [Route("")]
        [Route("{input}")]
        public async Task<ActionResult<AttemptResult>> Check(int input)
        {
            var result = _randomNumber.Check(input);
            if (result.AmIright)
            {
                _randomNumber = new RandomNumber();
            }

            return await Task.FromResult(result);
        }

        [Route("cheat")]
        [HttpGet]
        public async Task<ActionResult<AttemptResult>> Cheat()
        {
            var result = _randomNumber.Cheat();
            return await Task.FromResult(result);
        }

    }
}
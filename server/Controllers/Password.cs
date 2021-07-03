using System;
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
    public class PasswordController : ControllerBase
    {
        public PasswordController()
        {

        }

        [Route("")]
        [Route("{input}")]
        public async Task<ActionResult<AttemptResult>> Validate(string input)
        {
            return await Task.FromResult(new PasswordChecker().Validate(input));
        }

        [Route("cheat")]
        [HttpGet]
        public async Task<ActionResult<string>> Cheat()
        {
            string currentPassword = new PasswordChecker().Secret;
            return await Task.FromResult($"Well not everyone is smart enough, but keep trying.  Here the current password : {currentPassword}");
        }

    }
}
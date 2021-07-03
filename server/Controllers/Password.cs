using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
namespace server.Controllers
{
    #region TodoController
    [Route("")]
    [ApiController]
    public class PasswordController : ControllerBase
    {

        public PasswordController()
        {

        }
        #endregion

     

 
        [Route("")]
        [Route("{password}")]
        public async Task<ActionResult<AttemptResult>> Trial(string password)
        {
            string currentPassword = DateTime.Now.ToString("yyyyMMdd");


            return new AttemptResult(password, password == currentPassword);

        }

    }
}
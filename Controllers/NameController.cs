using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Test.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        // INJECT AUTH MANAGER CLASS -----------------------------------------------------------------------------
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public NameController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        // HANDLE LOGIN REQUEST ----------------------------------------------------------------------------------
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
        // REQUEST ENDPOINT --------------------------------------------------------------------------------------
        [HttpGet]
        public string Get()
        {
            var data = "You are authroize to see this data!";

            return data;
        }
    }
}

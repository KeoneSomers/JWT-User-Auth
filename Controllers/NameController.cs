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
        public IActionResult Authenticate([FromBody] UserModel userModel)
        {
            var token = jwtAuthenticationManager.Authenticate(userModel.Username, userModel.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
        // REQUEST ENDPOINT --------------------------------------------------------------------------------------
        [HttpGet]
        public string Get()
        {
            return "You are authroize to see this data!";
        }
    }
}

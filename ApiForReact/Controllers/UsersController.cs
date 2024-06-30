using ApiForReact.DTO;
using ApiForReact.Services;
using ClaenArch.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IAuthManager _authManager;

        public UsersController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLogin userLogin)
        {
            var token = _authManager.Authenticate(userLogin.Username, userLogin.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NyaaySetu.Authentication;
using NyaaySetu.Models;

namespace NyaaySetu.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly IJwtToken _jwtToken;
        public LoginController( IJwtToken jwtToken)
        {
                _jwtToken = jwtToken;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.Name) || string.IsNullOrEmpty(userModel.MobileNumber))
            {
                return BadRequest("Name and MobileNumber are required.");
            }
            var Token = _jwtToken.GeneratJwtToken(userModel);
            return Ok(new { AccessToken = Token });
        }
    }
}

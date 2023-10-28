using Cubitwelve.Src.DTOs;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDto loginUserDto)
        {
            var jwt = await _authService.Login(loginUserDto);

            if(jwt is null) return BadRequest("Invalid Credentials");

            return jwt;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterStudentDto registerStudentDto)
        {
            var token = await _authService.RegisterStudent(registerStudentDto);
            return token;
        }
    }
}
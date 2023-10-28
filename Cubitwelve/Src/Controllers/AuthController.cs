using Cubitwelve.Src.Auth.DTOs;
using Cubitwelve.Src.DTOs.Auth;
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

        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginUserDto loginUserDto)
        {
            var loginResponse = await _authService.Login(loginUserDto);

            if (loginResponse is null) return BadRequest("Invalid Credentials");
            return loginResponse;
        }

        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> Register(RegisterStudentDto registerStudentDto)
        {
            var loginResponse = await _authService.RegisterStudent(registerStudentDto);

            if (loginResponse is null) return BadRequest("Error Registering Student");
            return CreatedAtAction(nameof(Login), loginResponse);

        }

        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update-profile/{id}")]
        public async Task<ActionResult<LoginResponseDto>> UpdateProfile(int id, EditProfileDto editProfileDto)
        {
            var loginResponse = await _authService.EditProfile(id, editProfileDto);

            if (loginResponse is null) return BadRequest("Cannot update profile");
            return loginResponse;
        }
    }
}
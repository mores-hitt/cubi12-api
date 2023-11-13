using Cubitwelve.Src.DTOs.Auth;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var response = await _authService.Login(loginRequestDto);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> Register([FromBody] RegisterStudentDto registerStudentDto)
        {
            var loginResponse = await _authService.Register(registerStudentDto);
            return CreatedAtAction(nameof(Login), new { id = loginResponse.Id }, loginResponse);
        }

        [HttpPut("update-password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
        {
            await _authService.UpdatePassword(updatePasswordDto);
            return NoContent();
        }
    }
}
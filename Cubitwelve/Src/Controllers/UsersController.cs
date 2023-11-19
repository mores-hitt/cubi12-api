using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.DTOs.Profile;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
    public class UsersController : BaseAuthApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPut("update-profile")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<ActionResult<UserDto>> EditProfile([FromBody] EditProfileDto editProfileDto)
        {
            var user = await _usersService.EditProfile(editProfileDto);
            return Ok(user);
        }

        [HttpGet("profile")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(void), 401)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult<UserDto>> GetProfile()
        {
            var user = await _usersService.GetProfile();
            return Ok(user);
        }
    }
}
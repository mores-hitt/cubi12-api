using Cubitwelve.Src.Common.Constants;
using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.DTOs.Profile;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPut("update-profile")]
        [Authorize(Roles = RolesEnum.STUDENT)]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<ActionResult<UserDto>> EditProfile([FromBody] EditProfileDto editProfileDto)
        {
            var user = await _usersService.EditProfile(editProfileDto);
            return Ok(user);
        }
    }
}
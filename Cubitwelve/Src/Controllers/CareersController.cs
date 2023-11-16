using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
    public class CareersController : BaseApiController
    {
        private readonly ICareersService _careersService;

        public CareersController(ICareersService careersService)
        {
            _careersService = careersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CareerDto>>> GetAll()
        {
            var careers = await _careersService.GetAll();
            return Ok(careers);
        }
    }
}
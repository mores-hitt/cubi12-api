using Cubitwelve.Src.DTOs.Subjects;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
    [Authorize]
    public class SubjectsController : BaseApiController
    {
        private readonly ISubjectsService _subjectsService;

        public SubjectsController(ISubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectDto>>> GetAll()
        {
            var subjects = await _subjectsService.GetAll();
            return Ok(subjects);
        }
    }
}
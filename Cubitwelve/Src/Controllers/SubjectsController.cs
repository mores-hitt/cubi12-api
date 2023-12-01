using Cubitwelve.Src.DTOs.Progress;
using Cubitwelve.Src.DTOs.Subjects;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
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

        [HttpGet("prerequisites-map/objects")]
        public async Task<ActionResult<List<SubjectRelationshipDto>>> GetAllPreRequisitesMapObjects()
        {
            var relationships = await _subjectsService.GetAllRelationships();
            return Ok(relationships);
        }

        [HttpGet("prerequisites-map")]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetAllPreRequisitesMap()
        {
            var preRequisitesMap = await _subjectsService.GetPreRequisitesMap();
            return Ok(preRequisitesMap);
        }

        [HttpGet("postrequisites-map")]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetAllPostRequisitesMap()
        {
            var postRequisitesMap = await _subjectsService.GetPostRequisitesMap();
            return Ok(postRequisitesMap);
        }
    }
}
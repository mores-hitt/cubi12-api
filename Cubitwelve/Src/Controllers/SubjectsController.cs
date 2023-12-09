using Cubitwelve.Src.DTOs.Subjects;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Cubitwelve.Src.Controllers
{
    public class SubjectsController : BaseApiController
    {
        private readonly ISubjectsService _subjectsService;

        public SubjectsController(ISubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }

        [OutputCache]
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
        
        [OutputCache]
        [HttpGet("prerequisites-map")]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetAllPreRequisitesMap()
        {
            var preRequisitesMap = await _subjectsService.GetPreRequisitesMap();
            return Ok(preRequisitesMap);
        }

        [OutputCache]
        [HttpGet("postrequisites-map")]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetAllPostRequisitesMap()
        {
            var postRequisitesMap = await _subjectsService.GetPostRequisitesMap();
            return Ok(postRequisitesMap);
        }
    }
}
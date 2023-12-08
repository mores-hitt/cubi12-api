using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cubitwelve.Src.Controllers
{
    public class ResourcesController : BaseAuthApiController
    {
        private readonly IResourcesService _resourceService;

        public ResourcesController(IResourcesService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjectsResources()
        {
            var resources = await _resourceService.GetAllSubjectResources();
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourcesById(int id)
        {
            var resource = await _resourceService.GetSubjectResourceById(id);
            return Ok(resource);
        }
    }
}
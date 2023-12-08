using Cubitwelve.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetResources()
        {
            var resources = await _resourceService.GetAllSubjectResources();
            return Ok(resources);
        }
    }
}
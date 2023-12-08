using Cubitwelve.Src.DTOs.Resources;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IResourcesService
    {
        public Task<List<SubjectResourceDto>> GetAllSubjectResources();
    }
}
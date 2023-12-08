using Cubitwelve.Src.DTOs.Resources;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IResourcesService
    {
        public Task<List<SubjectResourceDto>> GetAllSubjectResources();

        public Task<List<ResourceDto>> GetSubjectResourceById(int id);
    }
}
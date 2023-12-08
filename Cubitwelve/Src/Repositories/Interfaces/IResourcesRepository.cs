using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Repositories.Interfaces;

public interface IResourcesRepository : IGenericRepository<SubjectResource> 
{
    public Task<List<Resource>> GetAllResources(int subjectResourceID);
}
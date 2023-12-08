using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cubitwelve.Src.Repositories;

public class ResourcesRepository : GenericRepository<SubjectResource>, IResourcesRepository
{
    public ResourcesRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Resource>> GetAllResources(int subjectResourceID)
    {
        var resources = await context.Resources
            .Where(r => r.SubjectResourceId == subjectResourceID)
            .ToListAsync();
        return resources;
    }
}
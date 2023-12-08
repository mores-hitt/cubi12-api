using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;

namespace Cubitwelve.Src.Repositories;

public class ResourcesRepository : GenericRepository<SubjectResource>, IResourcesRepository
{
    public ResourcesRepository(DataContext context) : base(context)
    {
    }
}
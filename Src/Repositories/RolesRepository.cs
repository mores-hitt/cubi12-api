using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;

namespace Cubitwelve.Src.Repositories
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository
    {
        public RolesRepository(DataContext context) : base(context)
        {
        }
    }
}
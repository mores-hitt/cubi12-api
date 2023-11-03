using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;

namespace Cubitwelve.Src.Repositories
{
    public class CareersRepository : GenericRepository<Career>, ICareersRepository
    {
        public CareersRepository(DataContext context) : base(context)
        {
        }
    }
}
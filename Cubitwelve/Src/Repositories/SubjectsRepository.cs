using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;

namespace Cubitwelve.Src.Repositories
{
    public class SubjectsRepository : GenericRepository<Subject>, ISubjectsRepository
    {
        public SubjectsRepository(DataContext context) : base(context)
        {
        }
    }
}
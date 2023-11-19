using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;

namespace Cubitwelve.Src.Repositories
{
    public class SubjectRelationshipsRepository : GenericRepository<SubjectRelationship>,
                                                ISubjectRelationshipsRepository
    {
        public SubjectRelationshipsRepository(DataContext context) : base(context)
        {
        }
    }
}
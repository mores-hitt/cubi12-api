using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Repositories.Interfaces
{
    public interface IRolesRepository
    {
        public Task<Role?> GetById(int id);

        public Task<Role?> GetByName(string name);

        public Task<Role> GetStudentRole();
    }
}
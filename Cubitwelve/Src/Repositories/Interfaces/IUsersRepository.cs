using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User?> GetById(int id);

        public Task<User?> GetByEmail(string email);

        public Task<List<User>> GetAll();

        public Task<User> Add(User user);
    }
}
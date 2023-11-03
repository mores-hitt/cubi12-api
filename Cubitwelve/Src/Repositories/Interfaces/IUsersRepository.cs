using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Repositories.Interfaces
{
    public interface IUsersRepository : IGenericRepository<User>
    {


        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        public Task<List<User>> GetAll();

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>User or null</returns>
        public Task<User?> GetByEmail(string email);

        /// <summary>
        /// Get user by rut
        /// </summary>
        /// <param name="rut">The RUT of the user</param>
        /// <returns>User or null</returns>
        public Task<User?> GetByRut(string rut);
    }
}
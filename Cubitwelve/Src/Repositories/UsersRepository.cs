using System.Linq.Expressions;
using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cubitwelve.Src.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly Expression<Func<User, bool>> softDeleteFilter = x => x.DeletedAt == null;

        public UsersRepository(DataContext context) : base(context) { }

        public async Task<List<User>> GetAll()
        {
            var users = await dbSet
                            .Where(softDeleteFilter)
                            .Include(x => x.Role)
                            .Include(x => x.Career)
                            .ToListAsync();
            return users;
        }

        public Task<User?> GetByEmail(string email)
        {
            var user = dbSet
                        .Where(softDeleteFilter)
                        .Include(x => x.Role)
                        .Include(x => x.Career)
                        .FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
using Cubitwelve.Src.Data;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cubitwelve.Src.Repositories
{
    public class RolesRepository : IRolesRepository
    {

        private readonly DataContext _context;

        public RolesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetById(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return role;
        }

        public async Task<Role?> GetByName(string name)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
            return role;
        }

        public async Task<Role> GetStudentRole()
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "student")
                ?? throw new Exception("Student role not found");
            return role;
        }
    }
}
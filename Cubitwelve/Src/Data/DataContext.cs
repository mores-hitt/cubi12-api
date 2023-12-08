using Cubitwelve.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Cubitwelve.Src.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<Subject> Subjects { get; set; } = null!;

        public DbSet<SubjectRelationship> SubjectsRelationships { get; set; } = null!;

        public DbSet<UserProgress> UsersProgress { get; set; } = null!;

        public DbSet<Career> Careers { get; set; } = null!;

        public DbSet<SubjectResource> SubjectResources { get; set; } = null!;

        public DbSet<Resource> Resources { get; set; } = null!;

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
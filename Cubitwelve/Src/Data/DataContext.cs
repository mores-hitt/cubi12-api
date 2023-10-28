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

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubjectRelationship>()
            .HasOne(sr => sr.Subject)
            .WithMany()
            .HasForeignKey(sr => sr.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubjectRelationship>()
            .HasOne(sr => sr.PreSubject)
            .WithMany()
            .HasForeignKey(sr => sr.PreSubjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    }
}
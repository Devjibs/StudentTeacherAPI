using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Repo.Data;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeacherData());
        modelBuilder.ApplyConfiguration(new StudentData());
    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
}

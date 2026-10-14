using Microsoft.EntityFrameworkCore;
using UniversityTask.Models;

namespace UniversityTask.Data;

public class UniversityDbContext : DbContext
{
    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost;Database=UniversityDb;Trusted_Connection=True;TrustServerCertificate=true");
    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Teachers)
            .WithOne(t => t.Department)
            .HasForeignKey(t => t.DepartmentId);
        modelBuilder.Entity<Department>()
            .HasMany(d => d.Courses)
            .WithOne(c => c.Department)
            .HasForeignKey(c => c.DepartmentId);

        modelBuilder.Entity<TeacherCourse>()
            .HasKey(tc => new { tc.TeacherId, tc.CourseId });
        modelBuilder.Entity<TeacherCourse>()
            .HasOne(tc => tc.Teacher)
            .WithMany(t => t.TeacherCourses)
            .HasForeignKey(tc => tc.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<TeacherCourse>()
            .HasOne(tc => tc.Course)
            .WithMany(c => c.TeacherCourses)
            .HasForeignKey(tc => tc.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Enrollment> Enrollments { get; set; } = null!;
    public DbSet<TeacherCourse> TeacherCourses { get; set; } = null!;
}

using Microsoft.EntityFrameworkCore;
using UniversityTask.Models;

namespace UniversityTask.Configuration;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.FullName).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Email).HasMaxLength(100);
        builder.HasIndex(t => t.Email).IsUnique();
        builder.HasMany(t => t.TeacherCourses)
               .WithOne(tc => tc.Teacher)
               .HasForeignKey(tc => tc.TeacherId);
        builder.HasOne(t => t.Department)
               .WithMany(d => d.Teachers)
               .HasForeignKey(t => t.DepartmentId);
    }
}

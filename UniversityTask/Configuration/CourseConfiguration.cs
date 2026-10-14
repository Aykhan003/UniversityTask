using Microsoft.EntityFrameworkCore;
using UniversityTask.Models;

namespace UniversityTask.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Credit).IsRequired();
        builder.HasMany(c => c.Enrollments)
               .WithOne(e => e.Course)
               .HasForeignKey(e => e.CourseId);
        builder.HasMany(c => c.TeacherCourses)
               .WithOne(tc => tc.Course)
               .HasForeignKey(tc => tc.CourseId);
        builder.HasOne(c => c.Department)
               .WithMany(d => d.Courses)
               .HasForeignKey(c => c.DepartmentId);
    }
}

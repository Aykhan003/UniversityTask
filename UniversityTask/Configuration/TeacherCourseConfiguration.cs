using Microsoft.EntityFrameworkCore;
using UniversityTask.Models;

namespace UniversityTask.Configuration;

public class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TeacherCourse> builder)
    {
        builder.HasKey(tc => new { tc.TeacherId, tc.CourseId });
        builder.HasOne(tc => tc.Teacher)
               .WithMany(t => t.TeacherCourses)
               .HasForeignKey(tc => tc.TeacherId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(tc => tc.Course)
               .WithMany(c => c.TeacherCourses)
               .HasForeignKey(tc => tc.CourseId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}

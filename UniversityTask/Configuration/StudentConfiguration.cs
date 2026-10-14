using Microsoft.EntityFrameworkCore;
using UniversityTask.Models;

namespace UniversityTask.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FullName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Email).HasMaxLength(100);
        builder.Property(s => s.BirthDate).IsRequired();
        builder.HasIndex(s => s.Email).IsUnique();
        builder.HasMany(s => s.Enrollments)
               .WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentId);
    }
}

using Microsoft.EntityFrameworkCore;
using UniversityTask.Models;

namespace UniversityTask.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Description).HasMaxLength(500);
        builder.HasMany(d => d.Teachers)
               .WithOne(t => t.Department)
               .HasForeignKey(t => t.DepartmentId);
        builder.HasMany(d => d.Courses)
               .WithOne(c => c.Department)
               .HasForeignKey(c => c.DepartmentId);
    }
}

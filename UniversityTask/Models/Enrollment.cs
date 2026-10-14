namespace UniversityTask.Models;

public class Enrollment
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public DateOnly EnrollmentDate { get; set; }
    public string? Grade { get; set; }
}

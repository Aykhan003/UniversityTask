namespace UniversityTask.Models;

public class Teacher
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? Email { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public List<TeacherCourse> TeacherCourses { get; set; } = new();
}

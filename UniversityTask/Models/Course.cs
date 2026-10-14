namespace UniversityTask.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Credit { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public List<Enrollment> Enrollments { get; set; } = new();
    public List<TeacherCourse> TeacherCourses { get; set; } = new();
}

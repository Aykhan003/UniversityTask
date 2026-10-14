namespace UniversityTask.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public List<Course> Courses { get; set; } = new();
    public List<Teacher> Teachers { get; set; } = new();
}

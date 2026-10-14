using Microsoft.EntityFrameworkCore;
using UniversityTask.Data;

using var context = new UniversityDbContext();
#region IncludeThenInclude
var departments = context.Departments.Include(d => d.Courses).ThenInclude(c => c.TeacherCourses).ThenInclude(tc => tc.Teacher).ToList();
foreach (var department in departments)
{
    Console.WriteLine($"Department: {department.Name}");
    foreach (var course in department.Courses)
    {
        Console.WriteLine($"\tCourse: {course.Name}, Credit: {course.Credit}");
        foreach (var teacherCourse in course.TeacherCourses)
        {
            Console.WriteLine($"\t\tTeacher: {teacherCourse.Teacher.FullName}, Email: {teacherCourse.Teacher.Email}");
        }
    }
}
var students = context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).ToList();
foreach (var student in students)
{
    Console.WriteLine($"Student: {student.FullName}, Email: {student.Email}");
    foreach (var enrollment in student.Enrollments)
    {
        Console.WriteLine($"\tEnrollment: {enrollment.Course.Name}, Credit: {enrollment.Course.Credit}");
    }
}
var courses = context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).ToList();
foreach (var course in courses)
{
    Console.WriteLine($"Course: {course.Name}, Credit: {course.Credit}");
    foreach (var enrollment in course.Enrollments)
    {
        Console.WriteLine($"\tEnrollment: {enrollment.Student.FullName}, Email: {enrollment.Student.Email}");
    }
}
#endregion

using School_Online.Courses.Models;

namespace School_Online.Courses.Service
{
    public interface ICourseComandService
    {
        Course AddCourse(Course course);
        int RemoveCourse(int id);
        Course UpdateCourse(int id, Course course);
    }
}

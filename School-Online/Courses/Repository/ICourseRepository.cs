using System.Collections.Generic;
using School_Online.Courses.Models;

namespace School_Online.Courses.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course AddCourse(Course course);
        Course Remove(int id);
        Course FindById(int id);
        Course UpdateCourse(int id, Course course);
    }
}

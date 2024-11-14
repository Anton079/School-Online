using System.Collections.Generic;
using School_Online.Courses.Models;

namespace School_Online.Courses.Service
{
    public interface ICourseQueryService
    {
        List<Course> GetAllCourses();
        Course FindCourseById(int id);
    }
}

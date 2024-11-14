using School_Online;
using School_Online.Courses.Models;
using School_Online.Courses.Repository;
using System.Collections.Generic;

namespace School_Online.Courses.Service
{
    public class CourseQueryService : ICourseQueryService
    {
        private ICourseRepository _courseRepository;

        public CourseQueryService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course FindCourseById(int id)
        {
            if (id != -1)
            {
                return _courseRepository.FindById(id);
            }
            return null;
        }
    }
}

using School_Online;
using School_Online.Courses.Models;
using School_Online.Courses.Repository;

namespace School_Online.Courses.Service
{
    public class CourseComandService : ICourseComandService
    {
        private ICourseRepository _courseRepository;

        public CourseComandService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Course AddCourse(Course course)
        {
            if (course != null)
            {
                _courseRepository.AddCourse(course);
                return course;
            }
            return null;
        }

        public int RemoveCourse(int id)
        {
            if (id != -1)
            {
                _courseRepository.Remove(id);
                return id;
            }
            return -1;
        }

        public Course UpdateCourse(int id, Course course)
        {
            if (id != -1 && course != null)
            {
                _courseRepository.UpdateCourse(id, course);
                return course;
            }
            return null;
        }
    }
}

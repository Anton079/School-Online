using online_school.Models;
using School_Online.Students.Repository;

namespace School_Online.Students.Service
{
    public class StudentComandService : IStudentComandService
    {
        private IStudentRepository _studentRepository;

        public StudentComandService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student AddStudent(Student student)
        {
            if (student != null)
            {
                _studentRepository.AddStudent(student);
                return student;
            }
            return null;
        }

        public int RemoveStudent(int id)
        {
            if (id != -1)
            {
                _studentRepository.Remove(id);
                return id;
            }
            return -1;
        }

        public Student UpdateStudent(int id, Student student)
        {
            if (id != -1 && student != null)
            {
                _studentRepository.UpdateStudent(id, student);
                return student;
            }
            return null;
        }
    }
}

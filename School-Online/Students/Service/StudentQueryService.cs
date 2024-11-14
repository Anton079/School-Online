using online_school.Models;
using School_Online.Students.Repository;
using System.Collections.Generic;

namespace School_Online.Students.Service
{
    public class StudentQueryService : IStudentQueryService
    {
        private IStudentRepository _studentRepository;

        public StudentQueryService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student FindStudentById(int id)
        {
            if (id != -1)
            {
                return _studentRepository.FindById(id);
            }
            return null;
        }
    }
}

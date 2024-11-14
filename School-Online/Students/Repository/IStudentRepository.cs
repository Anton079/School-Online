using online_school.Models;
using System.Collections.Generic;

namespace School_Online.Students.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student AddStudent(Student student);
        Student Remove(int id);
        Student FindById(int id);
        Student UpdateStudent(int id, Student student);
    }
}

using online_school.Models;
using System.Collections.Generic;

namespace School_Online.Students.Service
{
    public interface IStudentComandService
    {
        Student AddStudent(Student student);
        int RemoveStudent(int id);
        Student UpdateStudent(int id, Student student);
    }
}

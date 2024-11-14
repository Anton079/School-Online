using online_school.Models;
using System.Collections.Generic;

namespace School_Online.Students.Service
{
    public interface IStudentQueryService
    {
        List<Student> GetAllStudents();
        Student FindStudentById(int id);
    }
}

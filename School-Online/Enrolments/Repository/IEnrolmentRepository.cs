using School_Online.Enrolments.Models;
using System.Collections.Generic;

namespace School_Online.Enrolments.Repository
{
    public interface IEnrolmentRepository
    {
        List<Enrolment> GetAll();
        Enrolment AddEnrolment(Enrolment enrolment);
        Enrolment Remove(int studentId, int courseId);
        Enrolment FindByStudentAndCourseId(int studentId, int courseId);
        Enrolment UpdateEnrolment(int studentId, int courseId, Enrolment enrolment);
    }
}

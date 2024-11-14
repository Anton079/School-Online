using School_Online.Enrolments.Models;
using System.Collections.Generic;

namespace School_Online.Enrolments.Service
{
    public interface IEnrolmentQueryService
    {
        List<Enrolment> GetAllEnrolments();
        Enrolment FindEnrolmentByStudentAndCourseId(int studentId, int courseId);
    }
}

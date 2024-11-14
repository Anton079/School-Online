using School_Online.Enrolments.Models;

namespace School_Online.Enrolments.Service
{
    public interface IEnrolmentComandService
    {
        Enrolment AddEnrolment(Enrolment enrolment);
        bool RemoveEnrolment(int studentId, int courseId);
        Enrolment UpdateEnrolment(int studentId, int courseId, Enrolment enrolment);
    }
}

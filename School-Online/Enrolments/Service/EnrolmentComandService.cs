using School_Online.Enrolments.Models;
using School_Online.Enrolments.Repository;

namespace School_Online.Enrolments.Service
{
    public class EnrolmentComandService : IEnrolmentComandService
    {
        private IEnrolmentRepository _enrolmentRepository;

        public EnrolmentComandService(IEnrolmentRepository enrolmentRepository)
        {
            _enrolmentRepository = enrolmentRepository;
        }

        public Enrolment AddEnrolment(Enrolment enrolment)
        {
            if (enrolment != null)
            {
                _enrolmentRepository.AddEnrolment(enrolment);
                return enrolment;
            }
            return null;
        }

        public bool RemoveEnrolment(int studentId, int courseId)
        {
            Enrolment enrolment = _enrolmentRepository.Remove(studentId, courseId);
            return enrolment != null;
        }

        public Enrolment UpdateEnrolment(int studentId, int courseId, Enrolment enrolment)
        {
            if (studentId != -1 && courseId != -1 && enrolment != null)
            {
                _enrolmentRepository.UpdateEnrolment(studentId, courseId, enrolment);
                return enrolment;
            }
            return null;
        }
    }
}

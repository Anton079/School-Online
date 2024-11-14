using School_Online.Enrolments.Models;
using School_Online.Enrolments.Repository;
using System.Collections.Generic;

namespace School_Online.Enrolments.Service
{
    public class EnrolmentQueryService : IEnrolmentQueryService
    {
        private IEnrolmentRepository _enrolmentRepository;

        public EnrolmentQueryService(IEnrolmentRepository enrolmentRepository)
        {
            _enrolmentRepository = enrolmentRepository;
        }

        public List<Enrolment> GetAllEnrolments()
        {
            return _enrolmentRepository.GetAll();
        }

        public Enrolment FindEnrolmentByStudentAndCourseId(int studentId, int courseId)
        {
            return _enrolmentRepository.FindByStudentAndCourseId(studentId, courseId);
        }
    }
}

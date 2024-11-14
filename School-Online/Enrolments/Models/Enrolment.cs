using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Online.Enrolments.Models
{
    public class Enrolment
    {
        private int _studentId;
        private int _courseId;
        private int _createdAt;

        public Enrolment(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _studentId = int.Parse(token[0]);
            _courseId = int.Parse(token[1]);
            _createdAt = int.Parse(token[2]);
        }

        public Enrolment(int studentId, int courseId, int createdAt)
        {
            _studentId = studentId;
            _courseId = courseId;
            _createdAt = createdAt;
        }

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        public int CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        public int CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        public override string ToString()
        {
            return $"{StudentId},{CourseId},{CreatedAt}";
        }

        public string ToSave()
        {
            return _studentId + "," + _courseId + ',' + _createdAt;
        }
    }
}

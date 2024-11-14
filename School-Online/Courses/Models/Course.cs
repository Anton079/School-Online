using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Online.Courses.Models
{
    public class Course
    {
        private int _id;
        private string _name;
        private string _department;

        public Course(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _name = token[1];
            _department = token[2];
        }

        public Course(int id, string name, string department)
        {
            _id = id;
            _name = name;
            _department = department;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public override string ToString()
        {
            return $"{Id},{Name},{Department}";
        }

        public override bool Equals(object? obj)
        {
            Course course = obj as Course;
            return _id == course._id;
        }

        public string ToSave()
        {
            return _id + "," + _name + "," + _department;
        }
    }
}

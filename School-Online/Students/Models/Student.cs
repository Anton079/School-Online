using System;

namespace online_school.Models
{
    public class Student
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _age;
        private string _password;

        public Student(string proprietati)
        {
            String[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _firstName = token[1];
            _lastName = token[2];
            _email = token[3];
            _age = int.Parse(token[4]);
            _password = token[5];
        }

        public Student(int id, string firstName, string lastName, string email, int age, string password = "")
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _age = age;
            _password = password;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email 
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Password 
        {
            get { return _password; }
            set { _password = value; }
        }

        public override string ToString()
        {
            return $"{Id},{FirstName},{LastName},{Email},{Age},{Password}";
        }

        public override bool Equals(object? obj)
        {
            Student student = obj as Student;
            return _id == student._id;
        }

        public string ToSave()
        {
            return $"{Id},{FirstName},{LastName},{Email},{Age},{Password}";
        }
    }
}

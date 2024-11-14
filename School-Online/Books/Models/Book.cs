using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Online.Books.Models
{
    public class Book
    {
        private int _id;
        private int _studentId;
        private string _bookName;
        private int _createdAt;

        public Book(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _studentId = int.Parse(token[1]);
            _bookName = token[2];
            _createdAt = int.Parse(token[3]);
        }

        public Book(int id, int studentId, string bookName, int createAt)
        {
            _id = id;
            _studentId = studentId;
            _bookName = bookName;
            _createdAt = createAt;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        public string BookName
        {
            get { return _bookName; }
            set { _bookName = value; }
        }

        public int CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        public override string ToString()
        {
            return $"{Id},{StudentId},{BookName},{CreatedAt}";
        }

        public override bool Equals(object? obj)
        {
            Book book = obj as Book;
            return _id == book._id;
        }

        public string ToSave()
        {
            return _id + ',' + _studentId + ", " + _bookName + ',' + _createdAt;
        }
    }

}

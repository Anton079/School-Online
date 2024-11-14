using School_Online.Books.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace School_Online.Books.Repository
{
    public class BookRepository : IBookRepository
    {
        private List<Book> bookList;

        public BookRepository()
        {
            bookList = new List<Book>();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Book book = new Book(line);
                        bookList.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folder = Path.Combine(currentDirectory, "data");
            string file = Path.Combine(folder, "Books");
            return file;
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetFilePath()))
                {
                    sw.WriteLine(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string ToSaveAll()
        {
            string save = "";
            for (int i = 0; i < bookList.Count; i++)
            {
                save += bookList[i].ToString();
                if (i < bookList.Count - 1)
                {
                    save += "\n";
                }
            }
            return save;
        }

        // CRUD Operations

        public List<Book> GetAll()
        {
            return bookList;
        }

        public Book AddBook(Book book)
        {
            bookList.Add(book);
            SaveData();
            return book;
        }

        public Book Remove(int id)
        {
            Book book = FindById(id);
            if (book != null)
            {
                bookList.Remove(book);
                SaveData();
            }
            return book;
        }

        public Book FindById(int id)
        {
            foreach (Book book in bookList)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book UpdateBook(int id, Book book)
        {
            Book bookToUpdate = FindById(id);
            if (bookToUpdate != null)
            {
                bookToUpdate.StudentId = book.StudentId;
                bookToUpdate.BookName = book.BookName;
                bookToUpdate.CreatedAt = book.CreatedAt;
                SaveData();
            }
            return bookToUpdate;
        }
    }
}

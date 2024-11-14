using School_Online.Books.Models;
using System.Collections.Generic;

namespace School_Online.Books.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book AddBook(Book book);
        Book Remove(int id);
        Book FindById(int id);
        Book UpdateBook(int id, Book book);
    }
}

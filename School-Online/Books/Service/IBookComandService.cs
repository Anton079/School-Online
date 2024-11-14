using School_Online.Books.Models;

namespace School_Online.Books.Service
{
    public interface IBookComandService
    {
        Book AddBook(Book book);
        int RemoveBook(int id);
        Book UpdateBook(int id, Book book);
    }
}

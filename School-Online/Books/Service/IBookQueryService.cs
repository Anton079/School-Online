using School_Online.Books.Models;

namespace School_Online.Books.Service
{
    public interface IBookQueryService
    {
        List<Book> GetAllBooks();
        Book FindBookById(int id);
        int GenerateId();
    }
}

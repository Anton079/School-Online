using School_Online.Books.Models;
using School_Online.Books.Repository;

namespace School_Online.Books.Service
{
    public class BookComandService : IBookComandService
    {
        private IBookRepository _bookRepository;

        public BookComandService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book AddBook(Book book)
        {
            if (book != null)
            {
                _bookRepository.AddBook(book);
                return book;
            }
            return null;
        }

        public int RemoveBook(int id)
        {
            if (id != -1)
            {
                _bookRepository.Remove(id);
                return id;
            }
            return -1;
        }

        public Book UpdateBook(int id, Book book)
        {
            if (id != -1 && book != null)
            {
                _bookRepository.UpdateBook(id, book);
                return book;
            }
            return null;
        }
    }
}

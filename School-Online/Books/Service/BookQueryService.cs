using School_Online.Books.Models;
using School_Online.Books.Repository;
using System.Collections.Generic;

namespace School_Online.Books.Service
{
    public class BookQueryService : IBookQueryService
    {
        private IBookRepository _bookRepository;

        public BookQueryService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book FindBookById(int id)
        {
            if (id != -1)
            {
                return _bookRepository.FindById(id);
            }
            return null;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);

            while (FindBookById(id) != null)
            {
                id = rand.Next(1, 10000000);
            }

            return id;
        }
    }
}

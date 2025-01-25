using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }
        
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public void AddBook(Book? book)
        {
            if (book is null ) return;

            foreach (var bookAuthor in book.Authors)
            {
                var author = _authorRepository.GetById(bookAuthor);

                if (author is null)
                {
                    throw new Exception(
                        $"Author with id {bookAuthor} does not exist");
                }
            }

            _bookRepository.AddBook(book);
        }

        public Book? GetById(string id)
        {
            return _bookRepository.GetBookById(id);
        }
    }
}

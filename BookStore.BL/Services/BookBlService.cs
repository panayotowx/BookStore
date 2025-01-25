using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;
using BookStore.Models.Views;

namespace BookStore.BL.Services
{
    internal class BookBlService : IBookBlService
    {
        private readonly IBookService _bookService;
        private readonly IAuthorRepository _authorRepository;

        public BookBlService(
            IBookService bookService,
            IAuthorRepository authorRepository)
        {
            _bookService = bookService;
            _authorRepository = authorRepository;
        }

        public List<BookView> GetDetailedBooks()
        {
            var result = new List<BookView>();

            var books = _bookService.GetAllBooks();

            foreach (var book in books)
            {
                var bookView = new BookView
                {
                    BookId = book.Id,
                    BookTitle = book.Title,
                    BookYear = book.Year,
                    Authors = _authorRepository.GetAuthorsByIds(book.Authors)
                };

                result.Add(bookView);
            }

            return result;
        }
    }
}

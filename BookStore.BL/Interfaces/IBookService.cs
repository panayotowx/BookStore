using BookStore.Models.DTO;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();

        void AddBook(Book book);

        Book? GetById(string id);
    }
}

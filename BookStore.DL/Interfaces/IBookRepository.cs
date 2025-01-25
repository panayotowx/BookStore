using BookStore.Models.DTO;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        void AddBook(Book book);
        Book? GetBookById(string id);

        //void UpdateMovie(Movie movie);
        //void DeleteMovie(int id);
    }
}

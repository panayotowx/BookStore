using BookStore.Models.Views;

namespace BookStore.BL.Interfaces
{
    public interface IBookBlService
    {
        List<BookView> GetDetailedBooks();
    }
}

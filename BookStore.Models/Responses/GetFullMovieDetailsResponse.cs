using BookStore.Models.Views;

namespace BookStore.Models.Responses
{
    public class GetFullBookDetailsResponse
    {
        IEnumerable<BookView> Books { get; set; } = [];
    }
}

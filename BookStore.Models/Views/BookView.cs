using BookStore.Models.DTO;

namespace BookStore.Models.Views
{
    public class BookView
    {
        public string BookId { get; set; }

        public string BookTitle { get; set; } = string.Empty;

        public int BookYear { get; set; }

        public IEnumerable<Author> Author { get; set; } = [];
    }
}

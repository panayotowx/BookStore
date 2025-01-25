using BookStore.Models.DTO;

namespace BookStore.Models.Responses
{
    public class GetDetailedBookResponse
    {
        public Book Book { get; set; }

        public List<Author> Author { get; set; }
    }
}

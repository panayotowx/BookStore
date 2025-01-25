namespace BookStore.Models.DTO
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public List<string> Author { get; set; }
    }
}

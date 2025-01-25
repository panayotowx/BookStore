namespace BookStore.Models.Requests
{
    public class UpdateBookRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}

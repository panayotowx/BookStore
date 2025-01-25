using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories.MongoRepositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<BookRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _books = database.GetCollection<Book>(
                $"{nameof(Book)}s");
        }

        public List<Book> GetAllBooks()
        {
           return _books.Find(book => true).ToList();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                _logger.LogError("Book is null");
                return;
            }

            try
            {
                book.Id = Guid.NewGuid().ToString();

                _books.InsertOne(book);
            }
            catch (Exception e)
            {
               _logger.LogError(e,
                   $"Error adding book {e.Message}-{e.StackTrace}");
            }
           
        }

        public Book? GetBookById(string id)
        {
            if(string.IsNullOrEmpty(id)) return null;

            return _books.Find(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}

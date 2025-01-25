using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories.MongoRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Author> _authors;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<AuthorRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _authors = database.GetCollection<Author>(
                $"{nameof(Author)}s");
        }

        public void AddAuthor(Author author)
        {
            author.Id = System.Guid.NewGuid().ToString();
            _authors.InsertOne(author);
        }

        public void AddBook(Author movie)
        {
            if (movie == null)
            {
                _logger.LogError("Book is null");
                return;
            }

            try
            {
                movie.Id = Guid.NewGuid().ToString();

                _authors.InsertOne(movie);
            }
            catch (Exception e)
            {
               _logger.LogError(e,
                   $"Error adding movie {e.Message}-{e.StackTrace}");
            }
           
        }


        public IEnumerable<Author> GetAuthorsByIds(IEnumerable<string> authorsIds)
        {
            var result = _authors.Find(author => authorsIds.Contains(author.Id)).ToList();
            return result;
        }

        public Author? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return _authors.Find(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}

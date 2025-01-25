using BookStore.Models.DTO;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        void AddActor(Author author);
        IEnumerable<Author> GetAuthorssByIds(IEnumerable<string> authorsIds);
        Author? GetById(string id);
    }
}

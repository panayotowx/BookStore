using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories
{
    //public class AuthorStaticRepository : IAuthorRepository
    //{
    //    public IEnumerable<Author> GetAuthorsByIds(IEnumerable<int> AuthorsIds)
    //    {
    //        var result = new List<Author>();

    //        foreach (var AuthorsId in AuthorsIds)
    //        {
    //            foreach (var Author in StaticDB.InMemoryDb.Authors)
    //            {
    //                if (Author.Id == AuthorsId)
    //                {
    //                    result.Add(Author);
    //                }
    //            }
    //        }

    //        return result;

    //    }


    //    public Author? GetById(int id)
    //    {
    //        return StaticDB.InMemoryDb.Authors.
    //            FirstOrDefault(x => x.Id == id);
    //    }
    //}
}

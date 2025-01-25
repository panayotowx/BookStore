using BookStore.DL.StaticDB;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories
{
    //[Obsolete]
    //internal class BookStaticRepository 
    //{
    //    public List<Book> GetAllBooks()
    //    {
    //        return InMemoryDb.Books;
    //    }

    //    public void AddBook(Book Book)
    //    {
    //        if (Book == null) return;

    //        Book.Id = Guid.NewGuid().ToString();
    //        InMemoryDb.Books.Add(Book);
    //    }

    //    /// <summary>
    //    /// Get Book by id
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    public Book? GetBookById(string id)
    //    {
    //       return InMemoryDb.Books
    //           .FirstOrDefault(m => m.Id == id);
    //    }
    //}
}

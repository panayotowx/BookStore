using BookStore.Models.DTO;

namespace BookStore.DL.StaticDB
{
    internal static class InMemoryDb
    {
        internal static List<Author> Authors
            = new List<Author>
        {
            new Author
            {
                Id = "1",
                Name = "Tim Robbins"
            },
            new Author
            {
                Id = "2",
                Name = "Morgan Freeman"
            },
            new Author
            {
                Id = "3",
                Name = "Marlon Brando"
            },
            new Author
            {
                Id = "4",
                Name = "Al Pacino"
            },
            new Author
            {
                Id = "5",
                Name = "Christian Bale"
            },
            new Author
            {
                Id = "6",
                Name = "Heath Ledger"
            },
        };

        //internal static List<Movie> Movies = new List<Movie>
        //{
        //    new Movie
        //    {
        //        Id = "1",
        //        Title = "The Shawshank Redemption",
        //        Year = 1994,
        //        Actors = new List<int>
        //        {
        //            1, 2
        //        }
        //    },
        //    new Movie
        //    {
        //        Id = "2",
        //        Title = "The Godfather",
        //        Year = 1972,
        //        Actors = new List<int>
        //        {
        //            3, 4
        //        }
        //    },
        //    new Movie
        //    {
        //        Id = "3",
        //        Title = "The Dark Knight",
        //        Year = 2008,
        //        Actors = new List<int>
        //        {
        //            5, 6
        //    }
        //},
        //};
    }
}
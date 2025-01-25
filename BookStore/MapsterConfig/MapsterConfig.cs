using Mapster;
using BookStore.Models.DTO;
using BookStore.Models.Requests;

namespace BookStore.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<Book, AddBookRequest>
                .NewConfig()
                .TwoWays();
        }
    }
}

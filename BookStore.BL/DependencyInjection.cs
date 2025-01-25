using Microsoft.Extensions.DependencyInjection;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL;

namespace BookStore.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IBookBlService, BookBlService>();
            services.AddSingleton<IAuthorService, AuthorService>();

            return services;
        }

        public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
        {
            services.RegisterRepositories();

            return services;
        }
    }
}

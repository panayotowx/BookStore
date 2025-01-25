using BookStore.BL;

namespace BookStore
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterDataLayer();
            services.RegisterBusinessLayer();
        }
    }
}

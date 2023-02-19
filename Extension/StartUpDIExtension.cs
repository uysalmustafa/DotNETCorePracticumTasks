using ProductsAPI.Services;

namespace ProductsAPI.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}

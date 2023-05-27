using api.Data;
using api.EntityFrameworkHelpers;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection collection, IConfiguration config)
        {
            collection.AddControllers();
            collection.AddEndpointsApiExplorer();
            collection.AddSwaggerGen();

            collection.AddCors();

            collection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("SqliteConnection"));
            });

            collection.AddScoped<IUnitOfWork, UnitOfWork>(provider =>
            {
                return new UnitOfWork(provider.GetRequiredService<ApplicationDbContext>());
            });

            collection.AddSingleton<ImageService>();

            collection.AddScoped<BasketService>();
            collection.AddScoped<ProductService>();
            collection.AddScoped<CategoriesService>();
            collection.AddScoped<ProductImageService>();

            return collection;
        }
    }
}
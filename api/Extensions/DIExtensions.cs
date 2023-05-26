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

            collection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("SqliteConnection"));
            });

            collection.AddScoped<IUnitOfWork, UnitOfWork>(provider =>
            {
                return new UnitOfWork(provider.GetRequiredService<ApplicationDbContext>());
            });

            collection.AddScoped<BasketService>();
            collection.AddScoped<ProductService>();
            collection.AddScoped<CategoriesService>();

            return collection;
        }
    }
}
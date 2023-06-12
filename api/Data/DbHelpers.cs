using api.EntityFrameworkHelpers;
using api.Identity;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace api.Data
{
    public static class DbHelpers
    {
        public static async Task MigrateDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    await context.Database.MigrateAsync();
                    logger.LogInformation("Successfully migrated database");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, message: ex.Message);
                }
            }
        }

        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                await SeedUsers(services);
                await SeedProducts(services);
            }
        }

        private static async Task SeedProducts(IServiceProvider services)
        {
            var dbContext = services.GetRequiredService<ApplicationDbContext>();

            if (dbContext.Products.Any()) 
            {
                return;
            }

            var productsJSON = await File.ReadAllTextAsync("./Data/Seed/products.json");

            var jsonDocument = JsonDocument.Parse(productsJSON);

            var tasks = new List<Task<Product>>();

            foreach (var jsonElement in jsonDocument.RootElement.EnumerateArray())
            {
                tasks.Add(Task.Run(() => JsonSerializer.Deserialize<Product>(jsonElement.GetRawText()))!);
            }

            Product[] prods = await Task.WhenAll(tasks);

            dbContext.Products.AddRange(prods);
            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            try
            {
                if (await userManager.FindByNameAsync("Admin") is not null)
                    return;

                var user = new User
                {
                    UserName = "Admin",
                    Email = "admin@admin.com"
                };
                var result = await userManager.CreateAsync(user, "Pa$$w0rd");

                if (!result.Succeeded)
                {
                    logger.LogError("Failed to create an admin user");
                }

                await userManager.AddClaimAsync(user, new Claim(IdentityData.AdminUserClaimName, "true"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, message: ex.Message);
            }
        }
    }
}
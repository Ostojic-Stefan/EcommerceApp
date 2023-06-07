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

            var processorsJSON = await File.ReadAllTextAsync("./Data/Seed/processors.json");
            var processors = JsonSerializer.Deserialize<List<Product>>(processorsJSON);

            var HDDJSON = await File.ReadAllTextAsync("./Data/Seed/hard_drives.json");
            var HDDs = JsonSerializer.Deserialize<List<Product>>(HDDJSON);

            var memoryJSON = await File.ReadAllTextAsync("./Data/Seed/memory.json");
            var memory = JsonSerializer.Deserialize<List<Product>>(memoryJSON);

            dbContext.Products.AddRange(processors.Concat(HDDs).Concat(memory));
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
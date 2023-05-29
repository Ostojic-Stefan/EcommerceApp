using api.Identity;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<User>>();
                var logger = services.GetRequiredService<ILogger<Program>>();

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
}
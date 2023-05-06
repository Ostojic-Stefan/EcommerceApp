using Microsoft.EntityFrameworkCore;

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
                    logger.LogError(ex, ex.Message);
                }
            }
        }
    }
}
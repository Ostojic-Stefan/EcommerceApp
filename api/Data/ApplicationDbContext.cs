using api.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
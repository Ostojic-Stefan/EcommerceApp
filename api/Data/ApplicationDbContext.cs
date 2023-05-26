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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Graphics Cards",
                Icon = "Default"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Hard Drives",
                Icon = "Default"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "Computer Cases",
                Icon = "Default"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Name = "Motherboards",
                Icon = "Default"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 5,
                Name = "Memory",
                Icon = "Default"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 6,
                Name = "Power Supplies",
                Icon = "Default"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 7,
                Name = "Processors",
                Icon = "Default"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 8,
                Name = "SSDs",
                Icon = "Default"
            });
        }
    }
}
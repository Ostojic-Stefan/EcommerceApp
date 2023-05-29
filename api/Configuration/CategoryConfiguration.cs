using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = 1,
                Name = "Graphics Cards",
                Icon = "Default"
            });
            builder.HasData(new Category
            {
                Id = 2,
                Name = "Hard Drives",
                Icon = "Default"
            });
            builder.HasData(new Category
            {
                Id = 3,
                Name = "Computer Cases",
                Icon = "Default"
            });
            builder.HasData(new Category
            {
                Id = 4,
                Name = "Motherboards",
                Icon = "Default"
            });
            builder.HasData(new Category
            {
                Id = 5,
                Name = "Memory",
                Icon = "Default"
            });
            builder.HasData(new Category
            {
                Id = 6,
                Name = "Power Supplies",
                Icon = "Default"
            });
            builder.HasData(new Category
            {
                Id = 7,
                Name = "Processors",
                Icon = "Default"
            });
            builder.HasData(new Category
            {
                Id = 8,
                Name = "SSDs",
                Icon = "Default"
            });
        }
    }
}

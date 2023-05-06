using api.EntityFrameworkHelpers;

namespace api.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string ImageUrl { get; set; }
        public required string Type { get; set; }
        public required string Brand { get; set; }
        public int InStock { get; set; }
    }
}
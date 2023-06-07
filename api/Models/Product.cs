using api.EntityFrameworkHelpers;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public required string Brand { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }

        public required string Specifications { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [JsonPropertyName("productImage")]
        public ProductImage? ProductImage { get; set; }
    }
}
using api.EntityFrameworkHelpers;

namespace api.Models
{
    public class ProductImage : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public required string ImageName { get; set; }
        public required string Path { get; set; }
        public required string Url { get; set; }
    }
}

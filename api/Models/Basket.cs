using api.EntityFrameworkHelpers;

namespace api.Models
{
    public class Basket : BaseEntity
    {
        public required string CustomerId { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new();
    }
}

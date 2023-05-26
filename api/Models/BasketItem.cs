using api.EntityFrameworkHelpers;

namespace api.Models
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

using api.EntityFrameworkHelpers;

namespace api.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public required string Icon { get; set; }
    }
}

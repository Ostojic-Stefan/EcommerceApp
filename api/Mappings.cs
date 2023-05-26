using api.Models;

namespace api
{
    public static class Mappings
    {
        public static IEnumerable<ProductResponseDto> MapFromBasketToProductResponseDto(Basket basket)
        {
            var res = basket.BasketItems.Select(x =>
            {
                return new ProductResponseDto
                (
                    x.Product.Name,
                    x.Product.Description,
                    x.Product.Image,
                    x.Product.Brand,
                    x.Product.InStock,
                    x.Product.Price,
                    x.Quantity,
                    x.Product.CreatedAt,
                    x.Product.UpdatedAt
                );
            });
            return res;
        }

        public static Product MapFromProductDtoToProduct(AddProductDto addProductDto)
        {
            return new Product
            {
                Brand = addProductDto.Brand,
                CategoryId = addProductDto.CatergoryId,
                CreatedAt = DateTime.UtcNow,
                Description = addProductDto.Description,
                Image = addProductDto.Image,
                InStock = addProductDto.InStock,
                Name = addProductDto.Name,
                Price = addProductDto.Price,
            };
        }
    }
}

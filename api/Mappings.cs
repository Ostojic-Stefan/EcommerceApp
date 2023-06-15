using api.Models;
using api.QueryStringHelpers;

namespace api
{
    public static class Mappings
    {
        public static IEnumerable<BasketItemResponseDto> MapFromBasketToProductResponseDto(Basket basket)
        {
            var res = basket.BasketItems.Select(x =>
            {
                return new BasketItemResponseDto
                (
                    x.Product.Name,
                    x.Product.Description,
                    x.Product.ProductImage.Url,
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
                CategoryId = addProductDto.CategoryId,
                CreatedAt = DateTime.UtcNow,
                Description = addProductDto.Description,
                Specifications = addProductDto.Specifications,
                InStock = addProductDto.InStock,
                Name = addProductDto.Name,
                Price = addProductDto.Price,
            };
        }

        public static ProductResponseDto MapFromProductToProductResponseDto(Product product)
        {
            return new ProductResponseDto
            (
                product.Id,
                product.Name,
                product.Description,
                product.Specifications,
                product.ProductImage?.Url,
                product.Brand,
                product.InStock,
                product.Price,
                new CategoryResponseDto(
                    product.Category.Name,
                    product.Category.Icon
                ),
                product.CreatedAt,
                product.UpdatedAt
            );
        }

        public static PagedProductResponseDto MapToPagedProductResponseDto(PagedResponse<Product> product)
        {
            return new PagedProductResponseDto
            (
                product.PaginationParams,
                product.Data.Select(MapFromProductToProductResponseDto)
            );

        }
    }
}
